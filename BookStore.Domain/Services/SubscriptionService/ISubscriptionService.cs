using BookStore.Services.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services.Services.SubscriptionService
{
    public interface ISubscriptionService
    {
        Task<SubscriptionViewModel> SubscribeToBook(UserViewModel user, BookViewModel book);

        Task<List<SubscriptionViewModel>> SubscribeToBooks(UserViewModel user, List<BookViewModel> books);

    }
}
