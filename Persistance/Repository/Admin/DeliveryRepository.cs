using Application.CustomException;
using Application.DTOModels.Models.Admin.Delivery;
using Application.Services.Interfaces.IRepository.Admin;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAPIKurs;

namespace Persistance.Repository.Admin
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly WebsellContext _websellContext;
        private readonly IMapper _mapper;
        private readonly ILogger<Delivery> _logger;

        public DeliveryRepository(WebsellContext websellContext, IMapper mapper, ILogger<Delivery> logger)
        {
            _websellContext = websellContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Delivery> CreateDeliveryAsync(Delivery deliveryModel)
        {
            try
            {
                var result = await _websellContext.Deliveries.AddAsync(deliveryModel);

                if (result != null)
                {
                    await _websellContext.SaveChangesAsync();

                    return deliveryModel;
                }
                else
                {
                    throw new CustomRepositoryException($"Delivery ID ({deliveryModel.Id}) not found", "NOT_FOUND_ERROR_CODE");
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in DeliveryRepository.CreateDeliveryAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<Delivery> DeleteDeliveryAsync(int deliveryId)
        {
            try
            {
                var result = await _websellContext.Deliveries.FirstOrDefaultAsync(p => p.Id == deliveryId);

                if (result != null)
                {
                    _websellContext.Deliveries.Remove(result);

                    await _websellContext.SaveChangesAsync();

                    return result;
                }
                else
                {
                    throw new CustomRepositoryException($"Delivery ID ({deliveryId}) not found", "NOT_FOUND_ERROR_CODE");
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in DeliveryRepository.DeleteDeliveryAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<Delivery> EditDeliveryAsync(int deliveryId, DeliveryEditDto deliveryModel)
        {
            try
            {
                var delivery = await _websellContext.Deliveries.FirstOrDefaultAsync(p => p.Id == deliveryId);

                if (delivery != null)
                {
                    _mapper.Map(deliveryModel, delivery);

                    await _websellContext.SaveChangesAsync();

                    return delivery;
                }
                else
                {
                    throw new CustomRepositoryException($"Delivery ID ({deliveryId}) not found", "NOT_FOUND_ERROR_CODE");

                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in DeliveryRepository.EditDeliveryAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }
    }
}
