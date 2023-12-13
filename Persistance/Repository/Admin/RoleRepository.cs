using Application.CustomException;
using Application.DtoModels.Response.Admin;
using Application.DTOModels.Models.Admin.Roles;
using Application.Services.Interfaces.IRepository.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WebAPIKurs;

namespace Persistance.Repository.Admin
{
    public class RoleRepository : IRoleRepostitory
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<CustomUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<IdentityRole> _logger;

        public RoleRepository(RoleManager<IdentityRole> roleManager, UserManager<CustomUser> userManager, IMapper mapper, ILogger<IdentityRole> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IdentityRole> CreateRoleAsync(string roleName)
        {
            try
            {
                var role = new IdentityRole(roleName);

                IdentityResult result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return role;
                }
                else
                {
                    throw new Exception($"Internal Server Error" + string.Join(", ", result.Errors));
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in RoleRepository.CreateRoleAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<IdentityRole> DeleteRoleAsync(Guid roleId)
        {
            try
            {
                IdentityRole? role = await _roleManager.FindByIdAsync(roleId.ToString())
                    ?? throw new CustomRepositoryException("Role not found", "NOT_FOUND_ERROR_CODE");

                IdentityResult result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return role;
                }
                else
                {
                    throw new Exception($"Internal Server Error" + string.Join(", ", result.Errors));
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in RoleRepository.DeleteRoleAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<IdentityRole> EditRoleByIdAsync(EditRoleByIdDto editModel)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(editModel.Id)
                    ?? throw new CustomRepositoryException("Role not found", "NOT_FOUND_ERROR_CODE");

                role.Name = editModel.Name;

                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    var updatedRole = await _roleManager.FindByIdAsync(editModel.Id);

                    var roleResponseDto = _mapper.Map<RoleResponseDto>(updatedRole);

                    return role;
                }
                else
                {
                    throw new Exception($"Internal Server Error" + string.Join(", ", result.Errors));
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in RoleRepository.EditRoleByIdAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<UserResponseDto> EditUserRoleAsync(EditUserRoleDto editUser)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(editUser.UserId)
                    ?? throw new CustomRepositoryException($"User ID ({editUser.UserId}) not found", "NOT_FOUND_ERROR_CODE");

                var role = await _roleManager.FindByIdAsync(editUser.RoleId)
                    ?? throw new CustomRepositoryException($"Role ID ({editUser.RoleId}) not found", "NOT_FOUND_ERROR_CODE");

                var currentRoles = await _userManager.GetRolesAsync(user);

                var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);

                if (!removeResult.Succeeded)
                {
                    throw new Exception("Error removing user from roles: " + string.Join(", ", removeResult.Errors));
                }

                var addToRoleResult = await _userManager.AddToRoleAsync(user, role.Name);

                if (!addToRoleResult.Succeeded)
                {
                    throw new Exception("Error adding user to role: " + string.Join(", ", addToRoleResult.Errors));
                }

                var userWithRoleDto = _mapper.Map<UserResponseDto>(user);
                userWithRoleDto.Role = role.Name;

                return userWithRoleDto;
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in RoleRepository.EditUserRoleAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }
    }
}
