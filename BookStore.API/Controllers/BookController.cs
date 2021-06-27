using BookStore.CrossCuttingConcerns;
using BookStore.Services.Services.BookService;
using BookStore.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    /// <summary>
    /// Book Controller
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/Book")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ILogger _logger;
        
        public BookController(IBookService bookService, ILogger logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        /// <summary>
        /// Get Book
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("GetBook/{bookId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200, Type = typeof(BookViewModel))]
        public async Task<ActionResult> GetBookAsync(int bookId)
        {
            BookViewModel book;

            try
            {
                if (bookId < 0)
                    throw new Exception("BookId must be a positive integer");

                book = await _bookService.GetBookAsync(bookId);

                return Ok(book);
            }
            catch(Exception ex)
            {
                _logger.LogError($"GetBookAsync for bookId - {bookId} : {ex}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Books
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllBooks")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200, Type = typeof(List<BookViewModel>))]
        public async Task<ActionResult> GetAllBooksAsync()
        {
            List<BookViewModel> books;

            try
            {
                books = await _bookService.GetAllBooksAsync();

                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllBooksAsync : {ex}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Add Book
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddBook")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200, Type = typeof(BookViewModel))]
        public async Task<ActionResult> AddBookAsync([FromBody] BookViewModel book)
        {
            try
            {
                if (book == null || string.IsNullOrEmpty(book.Name) || 
                    string.IsNullOrEmpty(book.Text) || book.PurchasePrice < 0)
                    throw new Exception("Invalid book information");

                book.BookId = 0;

                book = await _bookService.AddBookAsync(book);

                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AddBookAsync : {ex}");
                return BadRequest(ex.Message);
            }
        }
    }
}
