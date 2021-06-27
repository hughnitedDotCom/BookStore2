using BookStore.CrossCuttingConcerns;
using BookStore.Services.Services.UserService;
using BookStore.Services.ViewModels;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors("AllowOrigin")]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest, StatusCode = 400, Type = typeof(BadRequestObjectResult))]
        public async Task<ActionResult> RegisterUserAsync([FromBody] RegisterRequest request)
        {
            UserViewModel user;

            try
            {
                if (request == null || string.IsNullOrEmpty(request.EmailAddress) ||
                    string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.Password))
                    throw new Exception("Invalid user details");

                user = await _userService.RegisterUserAsync(request);

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"RegisterUserAsync : {ex}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{email}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, StatusCode = 200, Type = typeof(UserViewModel))]
        public async Task<ActionResult> GetUserAsync(string email)
        {
            UserViewModel user;

            try
            {
                if (string.IsNullOrEmpty(email))
                    throw new Exception("Email is required");

                user = await _userService.GetUserAsync(email);

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetUserAsync for email - {email} : {ex}");
                return BadRequest(ex.Message);
            }
        }
    }
}
