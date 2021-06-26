using BookStore.CrossCuttingConcerns;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Services.Entities;
using BookStore.Services.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Services.Extensions;
using System;

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
            var book = await _bookRepository.GetByIdAsync(bookId);
                if (book == null) throw new Exception("Book does not exist");
            var user = await _userRepository.GetByIdAsync(userId);
                if (user == null) throw new Exception("User does not exist");

            var subscription = new Subscription
            {  
                BookId = book.Id,
                UserId = user.Id,
                IsActive = true
            };

            _logger.LogInformation($"SubscriptionService.SubscribeToBookAsync. UserId: {userId}, BookId: {bookId}");

            await _subscriptionRepository.AddAsync(subscription);

            user = await _userRepository.GetByIdAsync(user.Id);

            return user.ToViewModel();
        }

        public async Task<List<SubscriptionViewModel>> SubscribeToBooksAsync(UserViewModel user, List<BookViewModel> books)
        {
            var subscriptions = new List<Subscription>();

            foreach (var book in books)
            {
                subscriptions.Add(new Subscription
                {
                    UserId = user.UserId,
                    BookId = book.BookId,
                    IsActive = true
                });

                _logger.LogInformation($"SubscriptionService.SubscribeToBooksAsync. Email: {user.EmailAddress}, Book: {book.Name}");
            }
            
            var result = await _subscriptionRepository.AddRangeAsync(subscriptions);

            return result != null ? result.ToViewModelEnumerable()
                                          .ToList() : null;
        }

        #endregion
    }
}
