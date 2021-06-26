using BookStore.Services.Entities;
using BookStore.Services.ViewModels;
using System.Collections.Generic;

namespace BookStore.Services.Extensions
{
    public static class SubscriptionExtensions
    {
        public static SubscriptionViewModel ToViewModel(this Subscription subscription)
        {
            return new SubscriptionViewModel
            {
                Book = subscription.Book.ToViewModel(),

                ////stop toViewModel recursive mapping on User
                User = new UserViewModel
                {
                    UserId = subscription.UserId,
                    FirstName = subscription.User.FirstName,
                    LastName = subscription.User.LastName,
                    EmailAddress = subscription.User.EmailAddress
                }
            };
        }

        public static IEnumerable<SubscriptionViewModel> ToViewModelList(this ICollection<Subscription> subscriptions)
        {  
            foreach (var sub in subscriptions)
            {
               yield return sub.ToViewModel();
            }
        }  
    }
}
