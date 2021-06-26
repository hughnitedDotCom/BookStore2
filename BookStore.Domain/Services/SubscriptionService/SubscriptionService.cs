using BookStore.CrossCuttingConcerns;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Services.Entities;
using BookStore.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Services.Extensions;

namespace BookStore.Services.Services.SubscriptionService
{
    /// <summary>
    /// Subscription Service
    /// </summary>
    public class SubscriptionService : ISubscriptionService
    {
        #region Private Members

        IRepository<Subscription> _subscriptionRepository;
        ILogger _logger;

        #endregion

        #region Constructors
        public SubscriptionService(IRepository<Subscription> subscriptionRepository, ILogger logger)
        {
            _subscriptionRepository = subscriptionRepository;
            _logger = logger;
        }

        public async Task<SubscriptionViewModel> SubscribeToBook(UserViewModel user, BookViewModel book)
        {
            var subscription = new Subscription
            {
                User = user.ToEntity(),
                Book = book.ToEntity(),
                IsActive = true
            };

            var result = await _subscriptionRepository.AddAsync(subscription);

            return result.ToViewModel();
        }

        public async Task<List<SubscriptionViewModel>> SubscribeToBooks(UserViewModel user, List<BookViewModel> books)
        {
            var subscriptions = new List<Subscription>();

            foreach (var book in books)
            {
                subscriptions.Add(new Subscription
                {
                    User = user.ToEntity(),
                    Book = book.ToEntity(),
                    IsActive = true
                });
            }
            
            var result = await _subscriptionRepository.AddRangeAsync(subscriptions);

            return result.ToViewModelEnumerable()
                         .ToList();
        }

        #endregion
    }
}
