using Application.DTOModels.Models.Admin.Delivery;
using Application.DTOModels.Response.Admin;

namespace Application.Services.Interfaces.IServices.Admin
{
    public interface IDeliveryService
    {
        Task<DeliveryResponseDto> CreateDeliveryAsync(DeliveryCreateDto deliveryModel);

        Task<DeliveryResponseDto> EditDeliveryAsync(DeliveryEditDto deliveryModel);

        Task<DeliveryResponseDto> DeleteDeliveryAsync(int deliveryId);
    }
}
