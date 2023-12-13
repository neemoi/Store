using Application.DTOModels.Models.Admin.Payment;
using Application.DTOModels.Response.Admin;

namespace Application.Services.Interfaces.IServices.Admin
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> CreatePaymentAsync(PaymentCreateDto paymentModel);

        Task<PaymentResponseDto> EditPaymentAsync(PaymentEditDto paymentModel);

        Task<PaymentResponseDto> DeletePaymentAsync(int paymentId);
    }
}
