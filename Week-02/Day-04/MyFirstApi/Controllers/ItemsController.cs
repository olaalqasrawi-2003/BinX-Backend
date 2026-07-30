using MyFirstApi.Services;
using Microsoft.AspNetCore.Mvc;
namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IMessageSevice _messageService;
        public ItemsController(IMessageSevice messageSevice)
        {
            _messageService = messageSevice;
        }

        [HttpGet("message")]
         public IActionResult GetMessage()
        {
            return Ok(_messageService.GetMessage());
        }
       
       [HttpGet]  
       public IActionResult GetItems()
        {
            var items = new List<string>
            {
                "Laptop",
                "Mouse",
                "Keyboard"
            };
            return Ok(items);
        }

       [HttpGet("{id}")]
       public IActionResult GetItemById(int id)
        {
            var items = new List<string>
            {
                "Laptop",
                "Mouse",
                "Keyboard"
            };
            if(id < 1 || id > items.Count)
            {
                return NotFound("Item not found");
            }
            return Ok(items[id - 1]);
        }

    }
}