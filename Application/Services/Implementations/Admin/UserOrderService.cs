using Application.CustomException;
using Application.DTOModels.Models.Admin;
using Application.DTOModels.Response.User;
using Application.Services.Interfaces.IServices.Admin;
using Application.Services.UnitOfWork;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebAPIKurs;

namespace Application.Services.Implementations.Admin
{
    public class UserOrderService : IUserOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Order> _logger;

        public UserOrderService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Order> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserOrderResponseDto> EditUserOrderAsync(UserOrderEditDto editModel)
        {
            try
            {
                _logger.LogInformation("Attempt to edit an order: {@OrderEditDto}", editModel);

                var result = await _unitOfWork.UserOrderRepository.EditUserOrderAsync(editModel);

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Order successfully edit: {@Order}", result);

                return _mapper.Map<UserOrderResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when edit an order: {@OrderEditDto}", editModel);

                throw new CustomRepositoryException("Error occurred while edit an order: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
           
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the order: {@OrderEditDto}", editModel);

                throw new CustomRepositoryException("Error occurred during order mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }
    }
}
