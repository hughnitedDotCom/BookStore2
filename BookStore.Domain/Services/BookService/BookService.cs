using BookStore.Domain.Interfaces.Repository;
using BookStore.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Services.BookService
{
    public class BookService : IBookService
    {
        IRepository<Book> _userRepository;

        public BookService(IRepository<Book> userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
