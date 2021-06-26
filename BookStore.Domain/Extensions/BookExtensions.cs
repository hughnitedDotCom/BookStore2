using BookStore.Services.Entities;
using BookStore.Services.ViewModels;

namespace BookStore.Services.Extensions
{
    /// <summary>
    /// Conveniance extensions for Books
    /// </summary>
    public static class BookExtensions
    {
        public static BookViewModel ToViewModel(this Book book)
        {
            return new BookViewModel
            {
                BookId = book.Id,
                Name = book.Name,
                Text = book.Text,
                PurchasePrice = book.PurchasePrice
            };
        }


        public static Book ToEntity(this BookViewModel book)
        {
            return new Book
            {  
                Name = book.Name,
                Text = book.Text,
                PurchasePrice = book.PurchasePrice
            };
        }
    }
}
