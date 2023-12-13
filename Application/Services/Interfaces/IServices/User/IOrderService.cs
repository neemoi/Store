using Application.DTOModels.Models.User.Order;
using Application.DTOModels.Response.User;

namespace Application.Services.Interfaces.IServices.User
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrderAsync(OrderCreateDto orderModel, string token);

        Task<OrderResponseDto> EditOrderAsync(OrderEditDto orderModel, string token);

        Task<OrderResponseDto> DeleteOrderAsync(int orderId, string token);
    }
}
