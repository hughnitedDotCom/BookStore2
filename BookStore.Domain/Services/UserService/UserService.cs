using BookStore.Domain.Interfaces.Repository;
using BookStore.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Services.UserService
{
    /// <summary>
    /// User Service
    /// </summary>
    public class UserService : IUserService
    {
        IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

    }
}
