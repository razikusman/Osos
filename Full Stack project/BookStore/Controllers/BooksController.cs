using Microsoft.AspNetCore.Mvc;

namespace UserManagement
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<JsonResult> CreateEmployeeAAsync([FromBody] BookRequest bookRequest)
        {
            var res = await _bookService.CreateBookAsync(bookRequest);
            return Json(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _bookService.GetALlBookAsync();
            return Json(res);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var res = await _bookService.GetBookAsync(id);
            return Json(res);
        }

        [HttpPut]
        public async Task<JsonResult> UpdateBookAsync([FromBody] BookRequest bookRequest)
        {
            var res = await _bookService.UpdateBookAsync(bookRequest);
            return Json(res);
        }

        [HttpDelete("id")]
        public async Task<JsonResult> DeleteBookAsync(string id)
        {
            var res = await _bookService.DeleteBookAsync(id);
            return Json(res);
        }
    }
}
