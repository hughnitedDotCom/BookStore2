using BookStore.CrossCuttingConcerns;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Services.Entities;
using BookStore.Services.Extensions;
using BookStore.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Services.BookService
{
    public class BookService : IBookService
    {
        #region Private Members

        IRepository<Book> _bookRepository;
        ILogger _logger; 

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

            var books = await _bookRepository.GetAllAsync();

            foreach (var book in books)
            {
                booksView.Add(book.ToViewModel());
            }

            return booksView;
        }

        public async Task<BookViewModel> GetBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            return book.ToViewModel();
        }

        #endregion
    }
}
