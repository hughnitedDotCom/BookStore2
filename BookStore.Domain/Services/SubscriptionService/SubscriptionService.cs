using BookStore.CrossCuttingConcerns;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion
    }
}
