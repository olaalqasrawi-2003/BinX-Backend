using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using MyFirstApi.Models;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : Controller
    {
        private static readonly List<Book> books = new()
        {
            new Book
            {
                Id = 1,
                Title = "Clean Code",
                Author = "Robert C.Martin",
                Category = "Programming"
            },

            new Book
            {
                Id = 2,
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt",
                Category = "Programming"
            },
        };
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound("Book not found");
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook(Book newBook)
        {
            if(string.IsNullOrWhiteSpace(newBook.Title) || string.IsNullOrWhiteSpace(newBook.Author) || string.IsNullOrWhiteSpace(newBook.Category))
            {
                return BadRequest("Title , author , and category are required");
            }

            newBook.Id = books.Max(b => b.Id) + 1;
            books.Add(newBook);
            return CreatedAtAction(
                nameof(GetBookById),
                new{id = newBook.Id},
                newBook
            );
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound("Book not found");
            }
            if (string.IsNullOrWhiteSpace(updatedBook.Title) || string.IsNullOrWhiteSpace(updatedBook.Author) || string.IsNullOrWhiteSpace(updatedBook.Category))
            {
                return BadRequest("Title, author , and category are required");
            }
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Category = updatedBook.Category;

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound("Book not found");
            }
            books.Remove(book);
            return NoContent();
        }

        [HttpGet("/api/v1/categories/{category}/books")]
        public IActionResult GetBooksByCategory(string category)
        {
            var categoryBooks = books.Where(b => b.Category.Equals(category,StringComparison.OrdinalIgnoreCase)).ToList();
            if(categoryBooks.Count == 0)
            {
                return NotFound("No books found in this category");
            }
            return Ok(categoryBooks);
        }
    }
}