using BookStore.Services.Entities;
using BookStore.Services.ViewModels;
using System.Collections.Generic;
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
                BookSubscriptions = user.Subscriptions
                                        .Select(a => a.Book)
                                        .ToViewModelList()
                                        .ToList()
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
