using Application.DTOModels.Models.Admin;
using Application.DTOModels.Response.User;

namespace Application.Services.Interfaces.IServices.Admin
{
    public interface IUserOrderService
    {
        Task<UserOrderResponseDto> EditUserOrderAsync(UserOrderEditDto editModel);
    }
}
