﻿using BookStore.Services.Entities;
using BookStore.Services.ViewModels;
using System.Collections.Generic;

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
                Id = book.BookId,
                Name = book.Name,
                Text = book.Text,
                PurchasePrice = book.PurchasePrice
            };
        }

        public static IEnumerable<BookViewModel> ToViewModelList(this IEnumerable<Book> books)
        {   
            foreach (var book in books)
            {
                yield return book.ToViewModel();
            }
        }
    }
}
