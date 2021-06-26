using BookStore.CrossCuttingConcerns;
using BookStore.Services.Services.UserService;
using BookStore.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        readonly IUserService _userService;
        readonly ILogger _logger;

        public UserController(IUserService userService, ILogger logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <returns></returns>
        [HttpPost("Register")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200, Type = typeof(UserViewModel))]
        public async Task<ActionResult> RegisterUserAsync([FromBody] UserViewModel user)
        {
            try
            {
                if (user == null || string.IsNullOrEmpty(user.EmailAddress) ||
                    string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.Password))
                    throw new Exception("Invalid user details");

                user = await _userService.RegisterUserAsync(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"RegisterUserAsync : {ex.Message}");
                return BadRequest(ex);
            }
        }
    }
}
