using Application.CustomException;
using Application.DTOModels.Models.Admin.Delivery;
using Application.DTOModels.Response.Admin;
using Application.Services.Interfaces.IServices.Admin;
using Application.Services.UnitOfWork;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebAPIKurs;

namespace Application.Services.Implementations.Admin
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Delivery> _logger;

        public DeliveryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Delivery> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<DeliveryResponseDto> CreateDeliveryAsync(DeliveryCreateDto deliveryModel)
        {
            try
            {
                _logger.LogInformation("Attempt to create an delievry: {@DeliveryCreateDto}", deliveryModel);

                var delivery = _mapper.Map<Delivery>(deliveryModel);

                var result = await _unitOfWork.DeliveryRepository.CreateDeliveryAsync(delivery);

                _logger.LogInformation("Delivery successfully created: {@Delivery}", result);

                return _mapper.Map<DeliveryResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when creating an delivery: {@DeliveryCreateDto}", deliveryModel);

                throw new CustomRepositoryException("Error occurred while create an delivery: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the delivery: {@Delivery}", deliveryModel);

                throw new CustomRepositoryException("Error occurred during delivery mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }

        public async Task<DeliveryResponseDto> DeleteDeliveryAsync(int deliveryId)
        {
            try
            {
                _logger.LogInformation("Attempt to delete an delievry: {@Delivery}", deliveryId);

                var result = await _unitOfWork.DeliveryRepository.DeleteDeliveryAsync(deliveryId);

                _logger.LogInformation("Delivery successfully deleting: {@Delivery}", result);

                return _mapper.Map<DeliveryResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when deleting an delivery: {@Delivery}", deliveryId);

                throw new CustomRepositoryException("Error occurred while delete an delivery: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the delivery: {@Delivery}", deliveryId);

                throw new CustomRepositoryException("Error occurred during delivery mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }

        public async Task<DeliveryResponseDto> EditDeliveryAsync(DeliveryEditDto deliveryModel)
        {
            try
            {
                _logger.LogInformation("Attempt to edit an delievry: {@DeliveryEditDto}", deliveryModel);

                var result = await _unitOfWork.DeliveryRepository.EditDeliveryAsync(deliveryModel.Id, deliveryModel);

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Delivery successfully edit: {@Delivery}", result);

                return _mapper.Map<DeliveryResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when edit an delivery: {@DeliveryEditDto}", deliveryModel);

                throw new CustomRepositoryException("Error occurred while edit an delivery: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the delivery: {@DeliveryEditDto}", deliveryModel);

                throw new CustomRepositoryException("Error occurred during delivery mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }
    }
}
