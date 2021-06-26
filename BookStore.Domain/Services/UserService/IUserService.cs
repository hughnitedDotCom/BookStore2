using BookStore.Services.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.Services.UserService
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserAsync(int id);

        Task<List<UserViewModel>> GetAllUsersAsync();

        Task<UserViewModel> RegisterUserAsync(RegisterRequest user);
    }
}
