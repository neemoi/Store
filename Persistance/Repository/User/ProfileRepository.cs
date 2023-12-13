using Application.CustomException;
using Application.DTOModels.Models.User;
using Application.Services.Interfaces.IRepository.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPIKurs;

namespace Persistance.Repository.User
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<CustomUser> _userManager;

        public ProfileRepository(IMapper mapper, UserManager<CustomUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<CustomUser> EditProfileAsync(EditProfileDto model, string token)
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

                var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (!changePasswordResult.Succeeded)
                {
                    throw new Exception($"Error changing password: " + string.Join(", ", changePasswordResult.Errors));
                }

                _mapper.Map(model, user);

                var updateResult = await _userManager.UpdateAsync(user);

                if (updateResult.Succeeded)
                {
                    return user;
                }
                else
                {
                    throw new Exception($"Error update data: " + string.Join(", ", updateResult.Errors));
                }
            }
            catch (CustomRepositoryException ex)
            {
                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<CustomUser> GetAllInfoAsync(string token)
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

                var user = await _userManager.FindByIdAsync(userId);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new CustomRepositoryException($"User ID {userId} not found", "USER_NOT_FOUND_ERROR");
                }
            }
            catch (CustomRepositoryException ex)
            {
                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }
    }
}
