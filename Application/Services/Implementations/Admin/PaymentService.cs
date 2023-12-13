using Application.CustomException;
using Application.DTOModels.Models.Admin.Payment;
using Application.DTOModels.Response.Admin;
using Application.Services.Interfaces.IServices.Admin;
using Application.Services.UnitOfWork;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebAPIKurs;

namespace Application.Services.Implementations.Admin
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Order> _logger;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Order> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PaymentResponseDto> CreatePaymentAsync(PaymentCreateDto paymentModel)
        {
            try
            {
                _logger.LogInformation("Attempt to create an payment: {@PaymentCreateDto}", paymentModel);

                var payment = _mapper.Map<Payment>(paymentModel);

                var result = await _unitOfWork.PaymentsRepository.CreatePaymentAsync(payment);

                _logger.LogInformation("Order successfully created: {@Payment}", result);

                return _mapper.Map<PaymentResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when creating an payment: {@PaymentCreateDto}", paymentModel);

                throw new CustomRepositoryException("Error occurred while create an payment: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the payment: {@PaymentCreateDto}", paymentModel);

                throw new CustomRepositoryException("Error occurred during payment mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }

        public async Task<PaymentResponseDto> DeletePaymentAsync(int paymentId)
        {
            try
            {
                _logger.LogInformation("Attempt to delete an payment: {@Payment}", paymentId);

                var result = await _unitOfWork.PaymentsRepository.DeletePaymentAsync(paymentId);

                _logger.LogInformation("Order successfully delete: {@Payment}", result);

                return _mapper.Map<PaymentResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when delete an payment: {@Payment}", paymentId);

                throw new CustomRepositoryException("Error occurred while delete an payment: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the payment: {@Payment}", paymentId);

                throw new CustomRepositoryException("Error occurred during payment mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }

        public async Task<PaymentResponseDto> EditPaymentAsync(PaymentEditDto paymentModel)
        {
            try
            {
                _logger.LogInformation("Attempt to edit an edit: {@PaymentEditDto}", paymentModel);

                var result = await _unitOfWork.PaymentsRepository.EditPaymentAsync(paymentModel);

                await _unitOfWork.SaveChangesAsync();
                
                _logger.LogInformation("Order successfully edit: {@Payment}", result);

                return _mapper.Map<PaymentResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when edit an payment: {@PaymentEditDto}", paymentModel);

                throw new CustomRepositoryException("Error occurred while edit an payment: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the payment: {@PaymentEditDto}", paymentModel);

                throw new CustomRepositoryException("Error occurred during payment mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }
    }
}
