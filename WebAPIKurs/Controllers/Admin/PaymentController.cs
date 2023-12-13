using Application.DTOModels.Models.Admin.Pagination;
using Application.DTOModels.Models.Admin.Payment;
using Application.DTOModels.Response.Admin;
using Application.Services.Interfaces.IServices;
using Application.Services.Interfaces.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPIKurs.Controllers.Admin
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IPaginationService _paginationService;

        public PaymentController(IPaymentService paymentService, IPaginationService paginationService)
        {
            _paymentService = paymentService;
            _paginationService = paginationService;
        }

        /// <summary>
        /// Retrieves payments with pagination and filtering
        /// </summary>
        /// <remarks>
        /// Retrieves a list of payments based on specified parameters with pagination and filtering
        /// 
        ///     Example Request:
        /// 
        ///         GET Admin/Payment
        ///         {
        ///             "Page": 1,
        ///             "PageSize": 10,
        ///             "SortField": "Id",
        ///             "SortOrder": "asc",
        ///             "Id": "payment_id",
        ///             "Amount": "100.00",
        ///             "Type": "payment_type"
        ///         }
        /// 
        ///     - Page / PageSize: Page number and page size for pagination
        ///     - SortField: Field to sort the results by (e.g., Id, Amount)
        ///     - SortOrder: Sort order (asc or desc)
        ///     - Id: Payment ID to filter by
        ///     - Amount: Payment amount to filter by
        ///     - Type: Payment type to filter by
        ///     
        ///     Type:
        ///        card (amount 0.50$)
        ///        e-money (amount 3$)
        ///        cash (amount 3$)
        /// </remarks>
        /// <response code="200">List of payments retrieved successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "List of payments retrieved successfully", typeof(IEnumerable<PaymentResponseDto>))]
        [SwaggerResponse(400, "Invalid input data or request")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpGet("Admin/Payment")]
        public async Task<IActionResult> GetPaymentsWithPaginationAsync([FromQuery] PaymentQueryParametersDto productModel)
        {
            return Ok(await _paginationService.GetPaymentsWithPaginationAsync(productModel));
        }

        /// <summary>
        /// Creates a new payment
        /// </summary>
        /// <remarks>
        /// Creates a new payment entry based on the provided payment details
        /// 
        ///     Example Request:
        /// 
        ///         POST Admin/Payment
        ///         {
        ///             "Id": "payment_id",
        ///             "Amount": 100.00,
        ///             "Type": "payment_type"
        ///         }
        /// 
        ///     Type:
        ///        card (amount 0.50$)
        ///        e-money (amount 3$)
        ///        cash (amount 3$)
        /// </remarks>
        /// <response code="200">Payment created successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Payment created successfully", typeof(PaymentResponseDto))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPost("Admin/Payment")]
        public async Task<IActionResult> CreatePaymentAsync(PaymentCreateDto paymentModel)
        {
            return Ok(await _paymentService.CreatePaymentAsync(paymentModel));
        }

        /// <summary>
        /// Edits payment information
        /// </summary>
        /// <remarks>
        /// Edits payment information based on the provided payment data
        /// 
        ///     Example Request:
        /// 
        ///         PUT Admin/Payment
        ///         {
        ///             "Id": "payment_id",
        ///             "Amount": 120.00,
        ///             "Type": "updated_payment_type"
        ///         }
        /// 
        ///     Type:
        ///        card (amount 0.50$)
        ///        e-money (amount 3$)
        ///        cash (amount 3$)
        /// </remarks>
        /// <response code="200">Payment information updated successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Payment information updated successfully", typeof(PaymentResponseDto))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPut("Admin/Payment")]
        public async Task<IActionResult> EditPaymentAsync([FromBody] PaymentEditDto paymentModel)
        {
            return Ok(await _paymentService.EditPaymentAsync(paymentModel));
        }

        /// <summary>
        /// Deletes a payment
        /// </summary>
        /// <remarks>
        /// Deletes a payment with the provided payment ID
        /// 
        ///     Example Request:
        /// 
        ///         DELETE Admin/Payment
        ///         {
        ///             "id": 53
        ///         }
        /// 
        /// </remarks>
        /// <response code="200">Payment deleted successfully</response>
        /// <response code="404">Payment not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Payment deleted successfully", typeof(PaymentResponseDto))]
        [SwaggerResponse(404, "Payment not found")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpDelete("Admin/Payment/{id}")]
        public async Task<IActionResult> DeletePaymentAsync(int id)
        {
            return Ok(await _paymentService.DeletePaymentAsync(id));
        }
    }
}
