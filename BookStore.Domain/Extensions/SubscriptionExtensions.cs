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
                User = subscription.User.ToViewModel()
            };
        }

        public static IEnumerable<SubscriptionViewModel> ToViewModelEnumerable(this IEnumerable<Subscription> subscriptions)
        {
            foreach (var sub in subscriptions)
            {
                 yield return sub.ToViewModel();
            }
        }  
    }
}
