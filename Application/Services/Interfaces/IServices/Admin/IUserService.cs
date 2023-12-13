using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;

namespace Application.Services.Interfaces.IServices.Admin
{
    public interface IUserService
    {
        Task<UserResponseDto> EditUserAsync(UserDto model, string token);

        Task<UserResponseDto> DeleteUserAsync(string userId, string token);
    }
}