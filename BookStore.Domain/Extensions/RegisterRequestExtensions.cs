using BookStore.Services.Entities;
using BookStore.Services.ViewModels;

namespace BookStore.Services.Extensions
{
    public static class RegisterRequestExtensions
    {
        public static User ToUser(this RegisterRequest request)
        {
            return new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress,
                Password = request.Password
            };
        }

    }
}
