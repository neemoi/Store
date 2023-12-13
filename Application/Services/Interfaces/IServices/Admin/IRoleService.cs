using Application.DtoModels.Response.Admin;
using Application.DTOModels.Models.Admin.Roles;

namespace Application.Services.Interfaces.IServices.Admin
{
    public interface IRoleService
    {
        Task<RoleResponseDto> EditRoleByIdAsync(EditRoleByIdDto editModel);

        Task<RoleResponseDto> CreateRoleAsync(string roleName);

        Task<RoleResponseDto> DeleteRoleAsync(Guid roleId);

        Task<UserResponseDto> EditUserRoleAsync(EditUserRoleDto editUser);
    }
}
