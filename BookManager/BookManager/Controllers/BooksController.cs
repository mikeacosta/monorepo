using Microsoft.AspNetCore.Mvc;
namespace BookManager.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAllAsync());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _bookService.CreateAsync(book);
            return Ok(book.Id);
        }
    }
}