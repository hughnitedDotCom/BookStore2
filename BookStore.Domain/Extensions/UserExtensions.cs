using BookStore.Services.Entities;
using BookStore.Services.ViewModels;

namespace BookStore.Services.Extensions
{
    public static class UserExtensions
    {
        public static UserViewModel ToViewModel(this User user)
        {
            return new UserViewModel
            {
              FirstName = user.FirstName,
              LastName = user.LastName,
              EmailAddress = user.EmailAddress
            };
        }

        public static User ToEntity(this UserViewModel user)
        {
            return new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                Password = user.Password
            };
        }
    }
}
