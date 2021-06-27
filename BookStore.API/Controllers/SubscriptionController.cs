using BookStore.CrossCuttingConcerns;
using BookStore.Services.Services.SubscriptionService;
using BookStore.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    /// <summary>
    /// Subscription Controller
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/Subscription")]
    public class SubscriptionController : Controller
    {
        readonly ISubscriptionService _subscriptionService;
        readonly ILogger _logger;

        readonly string sqlLiteUniqueConstraintExceptionCode = "SQLite Error 19";

        public SubscriptionController(ISubscriptionService subscriptionService, ILogger logger)
        {
            _subscriptionService = subscriptionService;
            _logger = logger;
        }

        /// <summary>
        /// Subscribe to Book
        /// </summary>
        /// <returns></returns>
        [HttpPost("{userId}/Subscribe/{bookId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200, Type = typeof(SubscriptionViewModel))]
        public async Task<ActionResult> SubscribeAsync(int userId, int bookId)
        {
            SubscriptionViewModel subscription;

            try
            {
                if (userId <= 0 || bookId <= 0)
                    throw new Exception("Invalid subscription details");

                subscription = await _subscriptionService.SubscribeToBookAsync(userId, bookId);

                return Ok(subscription);
            }
            catch (Exception ex)
            {
                _logger.LogError($"SubscribeAsync : {ex}");

                var message = ex.InnerException.Message.Contains(sqlLiteUniqueConstraintExceptionCode) ? "Already subscribed to this book" : ex.Message;

                return BadRequest(message);
            }
        }

        /// <summary>
        /// Unsubscribe from Book
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{userId}/Unsubscribe/{bookId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200, Type = typeof(int))]
        public async Task<ActionResult> UnsubscribeAsync(int userId, int bookId)
        {
            try
            {
                if (userId <= 0 || bookId <= 0)
                    throw new Exception("Invalid subscription details");

                var result = await _subscriptionService.UnsubscribeFromBookAsync(userId, bookId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"UnsubscribeAsync : {ex}");

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Subscriptions
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("GetSubscriptions/{userId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200, Type = typeof(SubscriptionViewModel))]
        public async Task<ActionResult> GetSubscriptionsAsync(int userId)
        {
            List<SubscriptionViewModel> book;

            try
            {
                if (userId < 0)
                    throw new Exception("BookId must be a positive integer");

                book = await _subscriptionService.GetSubscriptionsAsync(userId);

                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetSubscriptionsAsync for userId - {userId} : {ex}");
                return BadRequest(ex.Message);
            }
        }

    }
}
