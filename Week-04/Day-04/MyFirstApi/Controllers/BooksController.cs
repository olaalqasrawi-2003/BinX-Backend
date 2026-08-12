using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Models;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
     public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "RequiredAdminEmail")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _context.Books
                .AsNoTracking()
                .ToListAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _context.Books
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound("Book not found");
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(CreateBookRequest request)
        {
            var newBook = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Category = request.Category
            };
           
           _context.Books.Add(newBook);
           await _context.SaveChangesAsync();

           return CreatedAtAction(
            nameof(GetBookById),
            new {id = newBook.Id},
            newBook);
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, UpdateBookRequest request)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound("Book not found");
            }

            book.Title = request.Title;
            book.Author = request.Author;
            book.Category = request.Category;

            await _context.SaveChangesAsync();

            return Ok(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound("Book not found");
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("/api/v1/categories/{category}/books")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByCategory(
            string category)
        {
            var books = await _context.Books
                .AsNoTracking()
                .Where(b => b.Category == category)
                .ToListAsync();

            if (books.Count == 0)
            {
                return NotFound("No books found in this category");
            }

            return Ok(books);
        }
    }
}