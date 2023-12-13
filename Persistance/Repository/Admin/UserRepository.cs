using Application.CustomException;
using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using Application.Services.Implementations.User;
using Application.Services.Interfaces.IRepository.Admin;
using Application.Services.Interfaces.IServices.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPIKurs;

namespace Persistance.Repository.Admin
{
    public class UserRepository : IUserRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<CustomUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<IdentityRole> _logger;
        private readonly WebsellContext _websellContext;

        public UserRepository(RoleManager<IdentityRole> roleManager, UserManager<CustomUser> userManager, IMapper mapper, ILogger<IdentityRole> logger, WebsellContext websellContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _websellContext = websellContext;
        }

        public async Task<CustomUser> DeleteUserAsync(string userId, string token)
        {
            try
            {
                var adminId = "e532e613-6ebb-4bff-abee-4eda9e69f13d";

                if (userId.ToString() == adminId)
                {
                    throw new CustomRepositoryException("You are trying to remove role the main administrator", "INVALID_INPUT_DATA");
                }

                var user = await _userManager.FindByIdAsync(userId)
                    ?? throw new CustomRepositoryException($"User ID ({userId}) not found", "NOT_FOUND_ERROR_CODE");

                var userOrders = _websellContext.Orders.Where(o => o.UserId == userId)
                    ?? throw new CustomRepositoryException($"User order not found", "NOT_FOUND_ERROR_CODE");

                _websellContext.Orders.RemoveRange(userOrders);

                var userRoles = await _userManager.GetRolesAsync(user);
                
                foreach (var role in userRoles)
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }

                var result = await _userManager.DeleteAsync(user);
                
                await _websellContext.SaveChangesAsync();

                if (result.Succeeded)
                {
                    return user;
                }
                else
                {
                    throw new Exception("Error adding user to role: " + string.Join(", ", result.Errors));
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when delet an user: {@CustomUser}", userId);

                throw new CustomRepositoryException("Error occurred while delete an user: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<CustomUser> EditUserAsync(UserDto userModel, string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jsonToken == null)
                {
                    throw new CustomRepositoryException("Invalid token format", "INVALID_TOKEN_FORMAT_ERROR");
                }

                var userId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value
                                  ?? throw new CustomRepositoryException("User ID not found in token", "INVALID_TOKEN_ERROR");

                var user = await _userManager.FindByIdAsync(userId)
                    ?? throw new CustomRepositoryException($"User ID ({userId}) not found", "NOT_FOUND_ERROR_CODE");

                _mapper.Map(userModel, user);

                var updateResult = await _userManager.UpdateAsync(user);

                if (updateResult.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    string userRole = roles.FirstOrDefault();

                    var userResponseDto = _mapper.Map<UserResponseDto>(user);
                    userResponseDto.Role = userRole;

                    return user;
                }
                else
                {
                    throw new Exception($"Error update data: " + string.Join(", ", updateResult.Errors));
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when edit an user: {@UserDto}", userModel);

                throw new CustomRepositoryException("Error occurred while edit an user: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }
    }
}
