using Application.DTOModels.Models.Admin;
using Application.DTOModels.Models.User.Order;
using WebAPIKurs;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface IUserOrderRepository
    {
        Task<Order> EditUserOrderAsync(UserOrderEditDto editModel);
    }
}
