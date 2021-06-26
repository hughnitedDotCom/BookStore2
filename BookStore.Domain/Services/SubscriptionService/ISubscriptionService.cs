using BookStore.Services.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.Services.SubscriptionService
{
    public interface ISubscriptionService
    {
        Task<UserViewModel> SubscribeToBookAsync(int userId, int bookId);

        Task<List<SubscriptionViewModel>> SubscribeToBooksAsync(UserViewModel user, List<BookViewModel> books);

        Task<List<SubscriptionViewModel>> GetSubscriptionsAsync(int userId);

    }
}
