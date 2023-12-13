using Application.CustomException;
using Application.DTOModels.Models.Admin;
using Application.DTOModels.Response.User;
using Application.Services.Interfaces.IRepository.Admin;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAPIKurs;

namespace Persistance.Repository.Admin
{
    public class UserOrderRepository : IUserOrderRepository
    {
        private readonly WebsellContext _websellContext;
        private readonly IMapper _mapper;
        private readonly ILogger<Order> _logger;

        public UserOrderRepository(WebsellContext websellContext, IMapper mapper, ILogger<Order> logger)
        {
            _websellContext = websellContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Order> EditUserOrderAsync(UserOrderEditDto editModel)
        {
            try
            {
                var order = await _websellContext.Orders
                   .Include(o => o.Orderitems)
                   .FirstOrDefaultAsync(p => p.UserId == editModel.UserId && p.UserId == editModel.UserId)
                   ?? throw new CustomRepositoryException("Order not found", "NOT_FOUND_ERROR_CODE");

                _mapper.Map(editModel, order);

                if (editModel.ListProductId != null && editModel.ListProductId.Any())
                {
                    order.Orderitems.Clear();

                    foreach (var productId in editModel.ListProductId)
                    {
                        var orderItem = new Orderitem
                        {
                            ProductId = productId,
                            Quantity = editModel.Quantity
                        };

                        order.Orderitems.Add(orderItem);
                    }
                }
                else
                {
                    throw new CustomRepositoryException("Order not found", "INVALID_INPUT_DATA");
                }

                order.TotalPrice = await CalculateTotalPriceAsync(editModel.PaymentId, editModel.DeliverId, editModel.ListProductId, editModel.Quantity);

                await LoadOrderDetailsAsync(order);

                await _websellContext.SaveChangesAsync();

                return order;
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in UserOrderRepository.EditUserOrderAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }
        private async Task LoadOrderDetailsAsync(Order order)
        {
            await _websellContext.Entry(order)
                .Collection(o => o.Orderitems)
                .Query()
                .Include(oi => oi.Product)
                .LoadAsync();

            await _websellContext.Entry(order)
                .Reference(o => o.Payments)
                .LoadAsync();

            await _websellContext.Entry(order)
                .Reference(o => o.Deliveries)
                .LoadAsync();

            var productPrices = order.Orderitems.Select(oi => oi.Product.Price).ToList() ?? throw new CustomRepositoryException("Price name not found", "NOT_FOUND_ERROR_CODE");
            var colorList = order.Orderitems.Select(oi => oi.Product.Color).ToList() ?? throw new CustomRepositoryException("Color name not found", "NOT_FOUND_ERROR_CODE");
            var memoryList = order.Orderitems.Select(oi => oi.Product.Memory).ToList() ?? throw new CustomRepositoryException("Memory name not found", "NOT_FOUND_ERROR_CODE");
            var nameList = order.Orderitems.Select(oi => oi.Product.Name).ToList() ?? throw new CustomRepositoryException("Product name not found", "NOT_FOUND_ERROR_CODE");

            var orderResponse = _mapper.Map<OrderResponseDto>(order);
            orderResponse.ListProductPrices = productPrices;
            orderResponse.ListProductName = nameList;
            orderResponse.ListProductColor = colorList;
            orderResponse.ListProductMemory = memoryList;
        }

        private async Task<decimal> CalculateTotalPriceAsync(int paymentId, int deliverId, List<int> productIds, int quantity)
        {
            decimal totalPrice = 0;

            foreach (var productId in productIds)
            {
                var product = await _websellContext.Products.FindAsync(productId) ?? throw new CustomRepositoryException("Product not found", "NOT_FOUND_ERROR_CODE");

                totalPrice += product.Price * quantity;
            }

            var payment = await _websellContext.Payments.FindAsync(paymentId) ?? throw new CustomRepositoryException("Payment ID not found", "NOT_FOUND_ERROR_CODE");
            var delivery = await _websellContext.Deliveries.FindAsync(deliverId) ?? throw new CustomRepositoryException("Delivery ID not found", "NOT_FOUND_ERROR_CODE");

            return totalPrice + payment.Amount + delivery.Price;
        }
    }
}
