using BookStore.CrossCuttingConcerns;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Services.Entities;
using BookStore.Services.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Services.Extensions;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services.Services.SubscriptionService
{
    /// <summary>
    /// Subscription Service
    /// </summary>
    public class SubscriptionService : ISubscriptionService
    {
        #region Private Members

        IRepository<Subscription> _subscriptionRepository;
        IRepository<Book> _bookRepository;
        IRepository<User> _userRepository;
        ILogger _logger;

        #endregion

        #region Constructors
        public SubscriptionService(IRepository<Subscription> subscriptionRepository,
            ILogger logger,
            IRepository<Book> bookRepository,
            IRepository<User> userRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<UserViewModel> SubscribeToBookAsync(int userId, int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(b => b.Id == bookId);
                if (book == null) throw new Exception("Book does not exist");
            var user = await _userRepository.GetByIdAsync(u => u.Id == userId);
                if (user == null) throw new Exception("User does not exist");

            var subscription = new Subscription { BookId = book.Id, UserId = user.Id };

            _logger.LogInformation($"SubscriptionService.SubscribeToBookAsync. UserId: {userId}, BookId: {bookId}");

            var result = await _subscriptionRepository.AddAsync(subscription);

            var updateResult = await _userRepository.GetByIdAsync(a => a.Id == user.Id);


            return updateResult.ToViewModel();
        }

        public async Task<UserViewModel> UnsubscribeFromBookAsync(int userId, int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(b => b.Id == bookId);
                if (book == null) throw new Exception("Book does not exist");
            var user = await _userRepository.GetByIdAsync(u => u.Id == userId);
                if (user == null) throw new Exception("User does not exist");

            _logger.LogInformation($"SubscriptionService.SubscribeToBookAsync. UserId: {userId}, BookId: {bookId}");

            var subscription = await _subscriptionRepository.GetByIdAsync(u => u.UserId == userId && u.BookId == bookId);

            var result = await _subscriptionRepository.DeleteAsync(subscription);

            var updateResult = await _userRepository.GetByIdAsync(a => a.Id == user.Id);

            return updateResult.ToViewModel();

        }

        public async Task<List<SubscriptionViewModel>> SubscribeToBooksAsync(UserViewModel user, List<BookViewModel> books)
        {
            var subscriptions = new List<Subscription>();

            //foreach (var book in books)
            //{
            //    subscriptions.Add(new Subscription
            //    {
            //        UserId = user.UserId,
            //        BookId = book.BookId,
            //    });

            //    _logger.LogInformation($"SubscriptionService.SubscribeToBooksAsync. Email: {user.EmailAddress}, Book: {book.Name}");
            //}

            //var result = await _subscriptionRepository.AddRangeAsync(subscriptions);

            //return result != null ? result.ToViewModelList()
            //                              .ToList() : null;

            return await Task.FromResult(new List<SubscriptionViewModel>());
        }

        public async Task<List<SubscriptionViewModel>> GetSubscriptionsAsync(int userId)
        {
            _logger.LogInformation($"SubscriptionService.GetSubscriptionsAsync. Fetching for userId: {userId}");

            var subscriptions = await _subscriptionRepository.GetAll()
                                                             .Where(sub => sub.UserId == userId)
                                                             .ToListAsync();

            return subscriptions != null ? subscriptions.ToViewModelList()
                                          .ToList() : null;

        }

        #endregion
    }
}
