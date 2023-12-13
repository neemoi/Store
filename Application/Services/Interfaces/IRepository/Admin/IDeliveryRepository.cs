using Application.DTOModels.Models.Admin.Delivery;
using WebAPIKurs;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface IDeliveryRepository
    {
        Task<Delivery> CreateDeliveryAsync(Delivery deliveryModel);

        Task<Delivery> EditDeliveryAsync(int deliveryId, DeliveryEditDto deliveryModel);

        Task<Delivery> DeleteDeliveryAsync(int deliveryId);
    }
}
