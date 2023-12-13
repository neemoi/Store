using Application.DTOModels.Models.Admin.Payment;
using WebAPIKurs;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface IPaymentsRepository
    {
        Task<Payment> CreatePaymentAsync(Payment payment);

        Task<Payment> EditPaymentAsync(PaymentEditDto paymentModel);

        Task<Payment> DeletePaymentAsync(int paymentId);
    }
}
