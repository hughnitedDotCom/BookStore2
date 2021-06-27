using BookStore.CrossCuttingConcerns;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Services.Entities;
using BookStore.Services.Extensions;
using BookStore.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.Services.BookService
{
    /// <summary>
    /// Book Service
    /// </summary>
    public class BookService : IBookService
    {
        #region Private Members

        readonly IRepository<Book> _bookRepository;
        readonly ILogger _logger;
        
        #endregion

        #region Constructors
        public BookService(IRepository<Book> bookRepository, ILogger logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
      
        #endregion

        #region Public Methods

        public async Task<List<BookViewModel>> GetAllBooksAsync()
        {
            var booksView = new List<BookViewModel>();

            _logger.LogInformation($"BookService.GetAllBooksAsync. Fetching all books");

            var books = await _bookRepository.GetAll()
                                             .ToListAsync();

            if(books != null && books.Count > 0)
            {
                books.ForEach(book => booksView.Add(book.ToViewModel()));
            }
            
            return booksView;
        }

        public async Task<BookViewModel> GetBookAsync(int id)
        {
            _logger.LogInformation($"BookService.GetBookAsync. Fetching book id: {id}");

            var book = await _bookRepository.GetByIdAsync(b => b.Id == id);

            return book != null ? book.ToViewModel() : null;
        }

        public async Task<BookViewModel> AddBookAsync(BookViewModel book)
        {
            _logger.LogInformation($"BookService.AddBookAsync. Adding book title: {book.Name}");

             var result = await _bookRepository.AddAsync(book.ToEntity());

            return result != null ? result.ToViewModel() : null;

        }

        #endregion
    }
}
