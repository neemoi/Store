using Application.CustomException;
using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using Application.Services.Interfaces.IServices.Admin;
using Application.Services.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WebAPIKurs;

namespace Application.Services.Implementations.Admin
{
    public class UserService : IUserService
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<IdentityRole> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(UserManager<CustomUser> userManager, IMapper mapper, ILogger<IdentityRole> logger, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponseDto> DeleteUserAsync(string userId, string token)
        {
            try
            {
                _logger.LogInformation("Attempt to delete an user: {@CustomUser}", userId);

                var result = await _unitOfWork.UserRepository.DeleteUserAsync(userId, token);

                _logger.LogInformation("Deliting successfully: {@CustomUser}", result);

                return _mapper.Map<UserResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when deleting an user: {@CustomUser}", userId);

                throw new CustomRepositoryException("Error occurred while delete an user: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the user: {@CustomUser}", userId);

                throw new CustomRepositoryException("Error occurred during user mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }

        public async Task<UserResponseDto> EditUserAsync(UserDto userModel, string token)
        {
            try
            {
                _logger.LogInformation("Attempt to edit an user: {@UserDto}", userModel);

                var result = await _unitOfWork.UserRepository.EditUserAsync(userModel, token);

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("User successfully edit: {@CustomUser}", result);

                return _mapper.Map<UserResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when edit an user: {@UserDto}", userModel);

                throw new CustomRepositoryException("Error occurred while edit an user: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }
    }
}