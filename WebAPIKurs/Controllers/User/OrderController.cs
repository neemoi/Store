using Application.DTOModels.Models.Admin.Pagination;
using Application.DTOModels.Models.User.Order;
using Application.DTOModels.Response.User;
using Application.Services.Interfaces.IServices;
using Application.Services.Interfaces.IServices.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPIKurs.Controllers.User
{
    public class OrderController : Controller
    {
        private readonly IPaginationService _paginationService;
        private readonly IOrderService _orderService;

        public OrderController(IPaginationService paginationService, IOrderService orderService)
        {
            _paginationService = paginationService;
            _orderService = orderService;
        }

        /// <summary>
        /// Retrieves products with pagination and filtering for a user
        /// </summary>
        /// <remarks>
        /// Retrieves products based on specified parameters with pagination and filtering
        /// 
        ///     Example Request:
        /// 
        ///         GET User/Order/Product
        ///         {
        ///            "ProductPage": 1,
        ///            "PageSize": 10,
        ///            "SortField": Name,
        ///            "SortOrder": asc,
        ///            "ProductId": 21,
        ///            "Name": product_name,
        ///            "Price": 100,
        ///            "Color": blue,
        ///            "Memory": 8GB,
        ///            "CategoryName": Phone
        ///         }
        /// 
        ///     - Page / PageSize: Page number and page size for pagination
        ///     - SortField: Field to sort the results by (e.g., Name, Price)
        ///     - SortOrder: Sort order (asc or desc)
        ///     - Name: Product name to filter by
        ///     - Price: Product price to filter by
        ///     - Color: Product color to filter by
        ///     - Memory: Product memory capacity to filter by
        ///     - CategoryName: Product category name to filter by
        /// 
        ///     CategoryName: Phone, Watch, Headphones, Pixel Tablet, Accessories
        /// </remarks>
        /// <response code="200">List of products retrieved successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "List of products", typeof(IEnumerable<UserProductResponseDto>))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpGet("User/Order/Product")]
        public async Task<IActionResult> UserGetProductWithPaginationAsync([FromQuery] UserProductQueryParametersDto productModel)
        {
            return Ok(await _paginationService.UserGetProductWithPaginationAsync(productModel));
        }

        /// <summary>
        /// Retrieves orders with pagination and filtering for a user
        /// </summary>
        /// <remarks>
        /// Retrieves orders based on specified parameters with pagination and filtering
        /// 
        ///     Example Request:
        /// 
        ///         GET User/Order
        ///         {
        ///            "Page": 1,
        ///            "PageSize": 10,
        ///            "SortField": CreatedAt,
        ///            "SortOrder": ascOrder,
        ///            "Id": 12345,
        ///            "CreateAt": 2023-11-20,
        ///            "Status": new,
        ///            "TotalPrice": 100,
        ///            "DeliveryId": 5,
        ///            "PaymentId": 3
        ///         }
        /// 
        ///     - Page / PageSize: Page number and page size for pagination
        ///     - SortField: Field to sort the results by (e.g., CreatedAt, TotalPrice)
        ///     - SortOrder: Sort order (asc or desc)
        ///     - OrderId: Order ID to filter by
        ///     - CreateAt: Date of order creation to filter by
        ///     - Status: Order status to filter by
        ///     - TotalPrice: Total price of the order to filter by
        ///     - DeliveryId: Delivery ID to filter by
        ///     - PaymentId: Payment ID to filter by
        ///     
        ///     paymentId:
        ///         5 - card (amount 0.50$)
        ///         6 - e-money (amount 3$)
        ///         7 - cash (amount 3$)
        ///     
        ///     deliverId:
        ///         2 - mail (price 30$)
        ///         3 - pickup (price 0$)
        ///         4 - courier (price 15$)
        /// </remarks>
        /// <response code="200">List of orders retrieved successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "List of orders", typeof(IEnumerable<UserProductResponseDto>))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpGet("User/Order")]
        public async Task<IActionResult> UserGetOrderWithPaginationAsync([FromQuery] UserOrderQueryParametersDto orderModel)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token is missing");
            }

            return Ok(await _paginationService.UserGetOrderWithPaginationAsync(orderModel, token));
        }

        /// <summary>
        /// Create a new order for the user
        /// </summary>
        /// <remarks>
        /// Creates a new order based on the provided data 
        /// 
        ///     Request example:
        ///     
        ///         POST User/Order
        ///         {
        ///           "listProductId": [1, 2, 3],
        ///           "paymentId": 5,
        ///           "deliverId": 2,
        ///           "quantity": 1
        ///         }
        ///         
        ///     paymentId:
        ///         5 - card (amount 0.50$)
        ///         6 - e-money (amount 3$)
        ///         7 - cash (amount 3$)
        ///     
        ///     deliverId:
        ///         2 - mail (price 30$)
        ///         3 - pickup (price 0$)
        ///         4 - courier (price 15$)
        /// </remarks>
        /// <response code="200">Order successfully created</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="404">User or product not found, or required fields are missing</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Order successfully created", typeof(OrderResponseDto))]
        [SwaggerResponse(400, "Invalid input data or request")]
        [SwaggerResponse(404, "User or product not found, or required fields are missing")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPost("User/Order")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderCreateDto orderModel)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token is missing");
            }

            return Ok(await _orderService.CreateOrderAsync(orderModel, token));
        }

        /// <summary>
        /// Edit order for the user
        /// </summary>
        /// <remarks>
        /// Modifies the order based on the data provided
        /// 
        ///     Request example:
        ///     
        ///         PUT User/Order
        ///         {
        ///           "orderId": 53,
        ///           "listProductId": [1, 2, 3],
        ///           "paymentId": 5,
        ///           "deliverId": 2,
        ///           "quantity": 1
        ///         }
        ///     
        ///     paymentId:
        ///         5 - card (amount 0.50$)
        ///         6 - e-money (amount 3$)
        ///         7 - cash (amount 3$)
        ///     
        ///     deliverId:
        ///         2 - mail (price 30$)
        ///         3 - pickup (price 0$)
        ///         4 - courier (price 15$)
        /// </remarks>
        /// <response code="200">Order successfully edit</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="404">User or product not found, or required fields are missing</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Order successfully edit", typeof(OrderResponseDto))]
        [SwaggerResponse(400, "Invalid input data or request")]
        [SwaggerResponse(404, "User or product not found, or required fields are missing")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPut("User/Order")]
        public async Task<IActionResult> EditOrderAsync([FromBody]OrderEditDto orderModel)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token is missing");
            }

            return Ok(await _orderService.EditOrderAsync(orderModel, token));
        }

        /// <summary>
        /// Delete order for the user
        /// </summary>
        /// <remarks>
        /// Delete the order based on the data provided
        /// 
        ///     Request example:
        ///     
        ///         DELETE User/Order
        ///         {
        ///           "orderId": 15,
        ///         }
        /// </remarks>
        /// <response code="200">Order successfully delete</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="404">User or product not found, or required fields are missing</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Order successfully delete", typeof(OrderResponseDto))]
        [SwaggerResponse(400, "Invalid input data or request")]
        [SwaggerResponse(404, "User or product not found, or required fields are missing")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpDelete("User/Order/{orderId}")]
        public async Task<IActionResult> DeleteOrderAsync(int orderId)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token is missing");
            }

            return Ok(await _orderService.DeleteOrderAsync(orderId, token));
        }
    }
}
