using BookStore.Services.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.Services.UserService
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserAsync(string email);

        Task<List<UserViewModel>> GetAllUsersAsync();

        Task<UserViewModel> RegisterUserAsync(RegisterRequest user);
    }
}
