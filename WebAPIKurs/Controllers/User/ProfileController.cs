using Application.CustomException;
using Application.DtoModels.Models.Admin;
using Application.DTOModels.Models.User;
using Application.Services.Interfaces.IServices.User;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPIKurs.Controllers.User
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        /// <summary>
        /// Get User information
        /// </summary>
        /// <remarks>
        /// Retrieves user information based on the current user ID
        /// 
        ///     Request example:
        ///     
        ///         GET User/Profile
        ///         {
        ///           "email": "user1@example.com",
        ///           "userName": "user1",
        ///           "phoneNumber": "48938176",
        ///           "address": "adress",
        ///           "city": "city",
        ///           "state": "state",
        ///         }
        ///         
        ///     `Email` must be a valid email address format (examplename@example.com)
        /// </remarks>
        /// <response code="200">User profile successfully found</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="404">User not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "User information found successfully", typeof(UserDto))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "User not found")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpGet("User/Profile")]
        public async Task<IActionResult> GetAllInfoAsync()
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (string.IsNullOrEmpty(token))
                {
                    return BadRequest("Token is missing");
                }

                return Ok(await _profileService.GetAllInfoAsync(token));
            }
            catch (CustomRepositoryException ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Update User profile
        /// </summary>
        /// <remarks>
        /// Updates the user profile based on the provided data
        ///     
        ///     Request example:
        ///     
        ///         PUT User/Profile
        ///         {
        ///           "email": "user1@example.com",
        ///           "userName": "user1",
        ///           "phoneNumber": "48938176",
        ///           "address": "adress",
        ///           "city": "city",
        ///           "state": "state",
        ///           "currentPassword": "avaKJ*1", required 
        ///           "newPassword": "avaKJ*1", required 
        ///         }
        ///         
        ///     Email must be a valid email address format (examplename@example.com)
        ///     Password passwords must have at least one uppercase ('A'-'Z', `1`-`0`, `!,@,#,$,%,^,*,(,),_,+,:,",',.,/,?`)
        /// </remarks>
        /// <param name="editModel">Model for updating the user profile</param>
        /// <response code="200">User profile successfully updated</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="404">User not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "User profile successfully updated", typeof(EditProfileDto))]
        [SwaggerResponse(400, "Invalid input data or request")]
        [SwaggerResponse(404, "User not found")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPut("User/Profile")]
        public async Task<IActionResult> EditProfileAsync([FromBody] EditProfileDto editModel)
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (string.IsNullOrEmpty(token))
                {
                    return BadRequest("Token is missing");
                }

                return Ok(await _profileService.EditProfileAsync(editModel, token));
            }
            catch (CustomRepositoryException ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
