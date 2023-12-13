using Application.DtoModels.Response.Admin;
using Application.DTOModels.Models.Admin.Roles;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface IRoleRepostitory
    {
        Task<IdentityRole> EditRoleByIdAsync(EditRoleByIdDto editModel);

        Task<IdentityRole> CreateRoleAsync(string roleName);

        Task<IdentityRole> DeleteRoleAsync(Guid roleId);

        Task<UserResponseDto> EditUserRoleAsync(EditUserRoleDto editUser);
    }
}
