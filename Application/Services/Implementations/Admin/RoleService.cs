using Application.CustomException;
using Application.DtoModels.Response.Admin;
using Application.DTOModels.Models.Admin.Roles;
using Application.Services.Interfaces.IServices.Admin;
using Application.Services.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Services.Implementations.Admin
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<IdentityRole> _logger;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<IdentityRole> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<RoleResponseDto> CreateRoleAsync(string roleName)
        {
            try
            {
                _logger.LogInformation("Attempt to create an role: {@IdentityRole}", roleName);

                var role = _mapper.Map<IdentityRole>(roleName);

                var result = await _unitOfWork.RoleRepostitory.CreateRoleAsync(roleName);

                _logger.LogInformation("Role successfully created: {@IdentityRole}", result);

                return _mapper.Map<RoleResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when creating an role: {@IdentityRole}", roleName);

                throw new CustomRepositoryException("Error occurred while create an role: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the role: {@IdentityRole}", roleName);

                throw new CustomRepositoryException("Error occurred during role mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }

        public async Task<RoleResponseDto> DeleteRoleAsync(Guid roleId)
        {
            try
            {
                _logger.LogInformation("Attempt to delete an role: {@IdentityRole}", roleId);

                var result = await _unitOfWork.RoleRepostitory.DeleteRoleAsync(roleId);

                _logger.LogInformation("Role successfully deleted: {@IdentityRole}", result);

                return _mapper.Map<RoleResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when deletet an role: {@IdentityRole}", roleId);

                throw new CustomRepositoryException("Error occurred while delete an role: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the role: {@IdentityRole}", roleId);

                throw new CustomRepositoryException("Error occurred during role mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }

        public async Task<RoleResponseDto> EditRoleByIdAsync(EditRoleByIdDto editModel)
        {
            try
            {
                _logger.LogInformation("Attempt to edit an role: {@EditRoleByIdDto}", editModel);

                var result = await _unitOfWork.RoleRepostitory.EditRoleByIdAsync(editModel);

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Role successfully edit: {@IdentityRole}", result);

                return _mapper.Map<RoleResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when edit an role: {@EditRoleByIdDto}", editModel);

                throw new CustomRepositoryException("Error occurred while edit an role: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the role: {@EditRoleByIdDto}", editModel);

                throw new CustomRepositoryException("Error occurred during role mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }

        public async Task<UserResponseDto> EditUserRoleAsync(EditUserRoleDto modelUser)
        {
            try
            {
                _logger.LogInformation("Attempt to edit an user role: {@EditUserRoleDto}", modelUser);

                var result = await _unitOfWork.RoleRepostitory.EditUserRoleAsync(modelUser);

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("User role successfully edit: {@IdentityRole}", result);

                return _mapper.Map<UserResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when edit an user role: {@EditUserRoleDto}", modelUser);

                throw new CustomRepositoryException("Error occurred while edit an user role: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the user role: {@EditUserRoleDto}", modelUser);

                throw new CustomRepositoryException("Error occurred during user role mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }
    }
}
