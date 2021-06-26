using BookStore.CrossCuttingConcerns;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Services.Entities;
using BookStore.Services.ViewModels;
using BookStore.Services.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace BookStore.Services.Services.UserService
{
    /// <summary>
    /// User Service
    /// </summary>
    public class UserService : IUserService
    {
        readonly IRepository<User> _userRepository;
        readonly ILogger _logger;

        public UserService(IRepository<User> userRepository, ILogger logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<UserViewModel> RegisterUserAsync(RegisterRequest request)
        {
            _logger.LogInformation($"UserService.RegisterUserAsync. User email: {request.EmailAddress}");

            var allUsers = await GetAllUsersAsync();

            var existingUser = allUsers.Any(u => u.EmailAddress == request.EmailAddress);

            if (existingUser)
                throw new Exception("Email already registered");

            var result = await _userRepository.AddAsync(request.ToUser());

            return result != null ? result.ToViewModel() : null;
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            var usersView = new List<UserViewModel>();

            _logger.LogInformation($"UserService.GetAllUsersAsync. Fetching all users");

            var users = await _userRepository.GetAllAsync();

            if (users != null && users.Count > 0)
            {
                users.ForEach(user => usersView.Add(user.ToViewModel()));
            }

            return usersView;
        }

        public async Task<UserViewModel> GetUserAsync(int id)
        {
            _logger.LogInformation($"UserService.GetUserAsync. Fetching user id: {id}");

            var user = await _userRepository.GetByIdAsync(id);

            return user != null ? user.ToViewModel() : null;
        }
    }
}
