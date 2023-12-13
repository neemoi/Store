using Application.CustomException;
using Application.DTOModels.Models.User;
using Application.DTOModels.Response.User;
using Application.Services.Interfaces.IRepository.User;
using Application.Services.Interfaces.IServices.User;
using Application.Services.UnitOfWork;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebAPIKurs;

namespace Application.Services.Implementations.User
{
    public class ProfileService : IProfileService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CustomUser> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(IMapper mapper, ILogger<CustomUser> logger, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<EditProfileResposneDto> EditProfileAsync(EditProfileDto editModel, string token)
        {
            try
            {
                _logger.LogInformation("Attempt to edit profile an user: {@EditProfileDto}", editModel);

                var result = await _unitOfWork.ProfileRepository.EditProfileAsync(editModel, token);
                
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("User profile successfully edit: {@CustomUser}", result);

                return _mapper.Map<EditProfileResposneDto>(result); 
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in ProfileService.EditProfileAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the CustomUser: {@CustomUser}");

                throw new CustomRepositoryException("Error occurred during CustomUser mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user profile.");

                throw new CustomRepositoryException("Internal Server Error", "INTERNAL_SERVER_ERROR");
            }
        }

        public async Task<EditProfileResposneDto> GetAllInfoAsync(string token)
        {
            try
            {
                _logger.LogInformation("Attempt to get info an user: {@CustomUser}");

                var user = await _unitOfWork.ProfileRepository.GetAllInfoAsync(token);

                _logger.LogInformation("Get info successfully: {@CustomUser}", user);

                return _mapper.Map<EditProfileResposneDto>(user);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in ProfileService.GetAllInfoAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the CustomUser: {@CustomUser}");

                throw new CustomRepositoryException("Error occurred during CustomUser mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }
    }
}
