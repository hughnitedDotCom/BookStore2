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
        /// Subscribe to Book User
        /// </summary>
        /// <returns></returns>
        [HttpPost("{userId}/Subscribe/{bookId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200, Type = typeof(UserViewModel))]
        public async Task<ActionResult> SubscribeAsync(int userId, int bookId)
        {
            UserViewModel subscription;

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

    }
}
