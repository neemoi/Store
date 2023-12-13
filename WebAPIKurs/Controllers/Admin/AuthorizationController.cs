using Application.CustomException;
using Application.DTOModels.Models.Admin.Authorization;
using Application.DTOModels.Response.Admin.Authorization;
using Application.Services.Interfaces.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIKurs.Controllers.Admin
{
    public class AuthorizationController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AuthorizationController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Logs in a user
        /// </summary>
        /// <remarks>
        /// Logs in a user based on the provided credentials
        /// 
        ///     Password passwords must have at least one uppercase ('A'-'Z', `1`-`0`, `!,@,#,$,%,^,*,(,),_,+,:,",',.,/,?`)
        /// </remarks>
        /// <response code="200">User logged in successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(LoginResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await _accountService.LoginAsync(model));
                }
                else
                {
                    throw new CustomRepositoryException("User not found. Check the correctness of the data", "INVALID_INPUT_DATA");
                }
            }
            catch (CustomRepositoryException ex)
            {
                throw new CustomRepositoryException("An error occurred while trying to LogIn: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <remarks>
        /// Registers a new user with the provided information
        /// 
        ///     Email must be a valid email address format (examplename@example.com)
        ///     
        ///     Password passwords must have at least one uppercase ('A'-'Z', `1`-`0`, `!,@,#,$,%,^,*,(,),_,+,:,",',.,/,?`)
        /// </remarks>
        /// <response code="200">User registered successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(RegisterDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await _accountService.RegisterAsync(model));
                }
                else
                {
                    throw new CustomRepositoryException("Check the correctness of the data", "INVALID_INPUT_DATA");
                }
            }
            catch (CustomRepositoryException ex)
            {
                throw new CustomRepositoryException("An error occurred while trying to Register: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        /// <summary>
        /// Logs out the current user.
        /// </summary>
        /// <remarks>
        /// Logs out the currently authenticated user
        /// </remarks>
        /// <response code="200">User logged out successfully</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("Logout")]
        [AllowAnonymous]
        public async Task<IActionResult> LogoutAsync()
        {
            return Ok(await _accountService.LogoutAsync(HttpContext));
        }
    }
}