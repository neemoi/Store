using Application.DTOModels.Models.User.Order;
using WebAPIKurs;

namespace Application.Services.Interfaces.IRepository.User
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(OrderCreateDto orderModel, string token);

        Task<Order> EditOrderAsync(OrderEditDto orderModel, string token);

        Task<Order> DeleteOrderAsync(int orderId, string token);
    }
}
