using BookStore.Services.Entities;
using BookStore.Services.ViewModels;
using System.Linq;

namespace BookStore.Services.Extensions
{
    public static class UserExtensions
    {
        public static UserViewModel ToViewModel(this User user)
        {
            return new UserViewModel
            {
              UserId = user.Id, 
              FirstName = user.FirstName,
              LastName = user.LastName,
              EmailAddress = user.EmailAddress,
              Subscriptions = user.Subscriptions.ToViewModelEnumerable().ToList()
            };
        }

        public static User ToEntity(this UserViewModel user)
        {
            return new User
            {
                Id = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                Password = user.Password
            };
        }
    }
}
