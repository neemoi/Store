using Application.DtoModels.Models.Admin;
using Application.DtoModels.Models.Pagination;
using Application.DTOModels.Models.Admin.Pagination;
using Application.DTOModels.Models.Admin.Roles;
using Application.Services.Interfaces.IServices;
using Application.Services.Interfaces.IServices.Admin;
using Application.Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Application.DTOModels.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using Application.DtoModels.Response.Admin;
using Application.DTOModels.Response.User;

namespace WebApi.Controllers.Admin
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPaginationService _paginationService;
        private readonly IRoleService _roleService;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUserService userService, IPaginationService paginationService, IRoleService roleService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _paginationService = paginationService;
            _roleService = roleService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retrieves users with pagination and filtering
        /// </summary>
        /// <remarks>
        /// Retrieves a list of users based on specified parameters with pagination and filtering
        /// 
        ///     Example Request:
        /// 
        ///         GET Admin/User
        ///         {
        ///            "Page": 1,
        ///            "PageSize": 10,
        ///            "SortField": userName,
        ///            "SortOrder": asc,
        ///            "Id": e532e613-6ebb-4bff-abee-4eda9e69f13d,
        ///            "UserName": username,
        ///            "Email": user@example.com,
        ///            "PhoneNumber": 123456789,
        ///            "State": state,
        ///            "City": city,
        ///            "Address"; address
        ///         }
        /// 
        ///     - Page / PageSize: Page number and page size for pagination
        ///     - SortField: Field to sort the results by (e.g., UserName, Email)
        ///     - SortOrder: Sort order (asc or desc)
        ///     - Id: User ID to filter by
        ///     - UserName: User name to filter by
        ///     - Email: Email address to filter by 
        ///     - PhoneNumber: Phone number to filter by
        ///     - State: State information to filter by
        ///     - City: City information to filter by
        ///     - Address: Address information to filter by
        ///     
        ///     `Email` must be a valid email address format (examplename@example.com)
        /// </remarks>
        /// <response code="200">List of users retrieved successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "List of users retrieved successfully", typeof(IEnumerable<UserResponseDto>))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpGet("Admin/User")]
        public async Task<IActionResult> GetUserWithPaginationAsync([FromQuery] UserQueryParametersDto parametersModel)
        {
            return Ok(await _paginationService.GetUserWithPaginationAsync(parametersModel));
        }

        /// <summary>
        /// Retrieves user orders with pagination and filtering
        /// </summary>
        /// <remarks>
        /// Retrieves a list of user orders based on specified parameters with pagination and filtering
        /// 
        ///     Example Request:
        /// 
        ///         GET Admin/User/Order
        ///         {
        ///            "userId": e532e613-6ebb-4bff-abee-4eda9e69f13d,
        ///            "Page": 1,
        ///            "PageSize": 10,
        ///            "SortField": CreatedAt,
        ///            "SortOrder": asc,
        ///            "Status": new,
        ///            "Price": 100,
        ///            "DeliveryId": 4,
        ///            "PaymentId": 5,
        ///            "Price": 500,
        ///            "Color": blue,
        ///            "Memory": 8GB
        ///         }
        /// 
        ///     - userId: The unique identifier of the user for whom orders are retrieved
        ///     - Page / PageSize: Page number and page size for pagination
        ///     - SortField: Field to sort the results by (e.g., CreatedAt, TotalPrice)
        ///     - SortOrder: Sort order (asc or desc)
        ///     - Status: Order status to filter by
        ///     - TotalPrice: Total order price to filter by
        ///     - DeliveryId: ID of the delivery to filter by
        ///     - PaymentId: ID of the payment to filter by
        ///     - Price: Product price within the order to filter by
        ///     - Color: Product color within the order to filter by
        ///     - Memory: Product memory within the order to filter by
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
        /// <response code="200">List of user orders retrieved successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "List of user orders retrieved successfully", typeof(IEnumerable<UserOrderResponseDto>))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpGet("Admin/User/Order")]
        public async Task<IActionResult> GeUserOrderWithPaginationAsync([FromQuery] GeUsertOrderQueryParametersDto parametersModel)
        {
            return Ok(await _paginationService.GeUserOrderWithPaginationAsync(parametersModel.UserId, parametersModel));
        }

        /// <summary>
        /// Edits a user's order based on provided parameters
        /// </summary>
        /// <remarks>
        /// Edits a user's order, updating order items and details
        /// 
        ///     Example Request:
        /// 
        ///         PUT /User/Order/Edit
        ///         {
        ///           "userId": "e532e613-6ebb-4bff-abee-4eda9e69f13d",
        ///           "paymentId": 123,
        ///           "deliverId": 456,
        ///           "listProductId": [1, 2, 3],
        ///           "quantity": 5
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
        /// <response code="200">Order updated successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Order updated successfully", typeof(UserOrderResponseDto))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPut("Admin/User/Order")]
        public async Task<IActionResult> EditUserOrderAsync(UserOrderEditDto orderModel)
        {
            return Ok(await _unitOfWork.UserOrderRepository.EditUserOrderAsync(orderModel));
        }

        /// <summary>
        /// Edits the role of a user
        /// </summary>
        /// <remarks>
        /// Edits the role of a user based on the provided user and role by ID
        /// 
        ///     Example Request:
        /// 
        ///         PUT /Admin/User/Role
        ///         {
        ///           "userId": "e532e613-6ebb-4bff-abee-4eda9e69f13d",
        ///           "roleId": "123e4567-e89b-12d3-a456-426614174000"
        ///         }
        ///         
        ///     roleId:
        ///       User: d968d618-f044-4a8c-a1ed-164133e36da4
        ///       Admin: 54b18c4c-e4a6-43ea-89ee-51c93a62f0ea
        /// </remarks>
        /// <response code="200">User role updated successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "User role updated successfully", typeof(UserResponseDto))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPut("Admin/User/Role")]
        public async Task<IActionResult> EditUserRoleAsync(EditUserRoleDto editUser)
        {
            return Ok(await _roleService.EditUserRoleAsync(editUser));
        }

        /// <summary>
        /// Edits user information
        /// </summary>
        /// <remarks>
        /// Edits user information based on the provided user data
        /// 
        ///     Example Request:
        /// 
        ///         PUT Admin/User
        ///         {
        ///           "id": "e532e613-6ebb-4bff-abee-4eda9e69f13d",
        ///           "email": "user1@example.com",
        ///           "userName": "user1",
        ///           "phoneNumber": "48938176",
        ///           "address": "adress",
        ///           "city": "city",
        ///           "state": "state",
        ///         }
        ///     
        ///     `Email` must be a valid email address format (examplename@example.com)
        /// </remarks>
        /// <response code="200">User information updated successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "User information updated successfully", typeof(UserResponseDto))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPut("Admin/User")]
        public async Task<IActionResult> EditUserAsync(UserDto userModel)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token is missing");
            }

            return Ok(await _userService.EditUserAsync(userModel, token));
        }

        /// <summary>
        /// Deletes a user by ID
        /// </summary>
        /// <remarks>
        /// Deletes a user based on the provided user ID
        /// 
        ///     Example Request:
        /// 
        ///         DELETE Admin/User
        ///         {
        ///            "id": "e532e613-6ebb-4bff-abee-4eda9e69f13d"
        ///         }
        /// </remarks>
        /// <response code="200">User deleted successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "User deleted successfully", typeof(UserResponseDto))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpDelete("Admin/User/{id}")]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token is missing");
            }

            return Ok(await _userService.DeleteUserAsync(id, token));
        }
    }
}