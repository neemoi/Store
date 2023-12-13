using Application.CustomException;
using Application.DTOModels.Models.Admin.Payment;
using Application.Services.Interfaces.IRepository.Admin;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAPIKurs;

namespace Persistance.Repository.Admin
{
    public class PaymentRepository : IPaymentsRepository
    {
        private readonly WebsellContext _websellContext;
        private readonly IMapper _mapper;
        private readonly ILogger<Payment> _logger;

        public PaymentRepository(WebsellContext websellContext, IMapper mapper, ILogger<Payment> logger)
        {
            _websellContext = websellContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            try
            {
                var result = await _websellContext.Payments.AddAsync(payment);

                if (result != null)
                {
                    await _websellContext.SaveChangesAsync();

                    return payment;
                }
                else
                {
                    throw new CustomRepositoryException("Payment not found", "NOT_FOUND_ERROR_CODE");
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in PaymentRepository.CreatePaymentAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<Payment> DeletePaymentAsync(int paymentId)
        {
            try
            {
                var result = await _websellContext.Payments.FirstOrDefaultAsync(p => p.Id == paymentId);

                if (result != null)
                {
                    _websellContext.Payments.Remove(result);

                    await _websellContext.SaveChangesAsync();

                    return result;
                }
                else
                {
                    throw new CustomRepositoryException($"Payment ID ({paymentId}) not found", "NOT_FOUND_ERROR_CODE");
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in PaymentRepository.DeletePaymentAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<Payment> EditPaymentAsync(PaymentEditDto paymentModel)
        {
            try
            {
                var result = await _websellContext.Payments.FirstOrDefaultAsync(p => p.Id == paymentModel.Id);

                if (result != null)
                {
                    _mapper.Map(paymentModel, result);

                    await _websellContext.SaveChangesAsync();

                    return result;
                }
                else
                {
                    throw new CustomRepositoryException($"Payment ID ({paymentModel.Id}) not found", "NOT_FOUND_ERROR_CODE");
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in PaymentRepository.EditPaymentAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }
    }
}
