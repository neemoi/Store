using Application.CustomException;
using Application.DTOModels.Models.User.Order;
using Application.DTOModels.Response.User;
using Application.Services.Interfaces.IServices.User;
using Application.Services.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using WebAPIKurs;

namespace Application.Services.Implementations.User
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Order> _logger;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Order> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OrderResponseDto> CreateOrderAsync(OrderCreateDto orderModel, string token)
        {
            try
            {
                _logger.LogInformation("Attempt to create an order: {@OrderCreateDto}", orderModel);

                var result = await _unitOfWork.OrderRepository.CreateOrderAsync(orderModel, token);

                _logger.LogInformation("Order successfully created: {@Order}", result);

                return _mapper.Map<OrderResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when creating an order: {@OrderCreateDto}", orderModel);

                throw new CustomRepositoryException("Error occurred while create an order: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the order: {@OrderCreateDto}", orderModel);

                throw new CustomRepositoryException("Error occurred during order mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }
        
        public async Task<OrderResponseDto> DeleteOrderAsync(int orderId, string token)
        {
            try
            {
                _logger.LogInformation("Attempt to delete an order: {@orderId}", orderId);
                
                var result = await _unitOfWork.OrderRepository.DeleteOrderAsync(orderId, token);

                _logger.LogInformation("Order successfully deleted: {@Order}", result);

                return _mapper.Map<OrderResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when delete an order: {@odrerId}", orderId);

                throw new CustomRepositoryException("Error occurred while deleting an order: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the order: {@Order}", orderId);

                throw new CustomRepositoryException("Error occurred during order mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }

        public async Task<OrderResponseDto> EditOrderAsync(OrderEditDto orderModel, string token)
        {
            try
            {
                _logger.LogInformation("Attempt to edit an order: {@OrderEditDto}", orderModel);

                var result = await _unitOfWork.OrderRepository.EditOrderAsync(orderModel, token);

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Order successfully edit: {@Order}", result);

                return _mapper.Map<OrderResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when edit an order: {@OrderEditDto}", orderModel);
             
                throw new CustomRepositoryException("Error occurred while edit an order: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex) 
            {
                _logger.LogError(ex, "Error when mapping the order: {@OrderEditDto}", orderModel);

                throw new CustomRepositoryException("Error occurred during order mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }
    }
}
