using Application.DtoModels.Models.Admin;
using WebAPIKurs;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface IUserRepository
    {
        Task<CustomUser> EditUserAsync(UserDto model, string token);

        Task<CustomUser> DeleteUserAsync(string userId, string token);
    }
}
