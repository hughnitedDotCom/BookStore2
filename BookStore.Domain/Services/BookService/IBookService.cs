using BookStore.Services.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.Services.BookService
{
    public interface IBookService
    {
        Task<BookViewModel> GetBookAsync(int id);

        Task<List<BookViewModel>> GetAllBooksAsync();
    }
}
