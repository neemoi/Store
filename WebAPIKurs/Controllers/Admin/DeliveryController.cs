using Application.Services.Interfaces.IServices.Admin;
using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Application.DTOModels.Models.Admin.Pagination;
using Application.DTOModels.Models.Admin.Delivery;
using Microsoft.AspNetCore.Authorization;
using Application.DTOModels.Response.Admin;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPIKurs.Controllers.Admin
{
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IPaginationService _paginationService;

        public DeliveryController(IDeliveryService deliveryService, IPaginationService paginationService)
        {
            _deliveryService = deliveryService;
            _paginationService = paginationService;
        }

        /// <summary>
        /// Retrieves deliveries with pagination and filtering
        /// </summary>
        /// <remarks>
        /// Retrieves a list of deliveries based on specified parameters with pagination and filtering
        /// 
        ///     Example Request:
        /// 
        ///         GET Admin/Delivery
        ///         {
        ///             "Page": 1,
        ///             "PageSize": 10,
        ///             "SortField": "Id",
        ///             "SortOrder": "asc",
        ///             "Id": "delivery_id",
        ///             "Price": "100.00",
        ///             "Type": "delivery_type"
        ///         }
        ///         
        ///     Type:
        ///         mail (price 30$)
        ///         pickup (price 0$)
        ///         courier (price 15$)
        /// </remarks>
        /// <response code="200">List of deliveries retrieved successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "List of deliveries", typeof(IEnumerable<DeliveryResponseDto>))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpGet("Admin/Delivery")]
        public async Task<IActionResult> GetDeliveryWithPaginationAsync([FromQuery] DeliveryQueryParametersDto deliveryModel)
        {
            return Ok(await _paginationService.GetDeliveryWithPaginationAsync(deliveryModel));
        }

        /// <summary>
        /// Creates a new delivery
        /// </summary>
        /// <remarks>
        /// Creates a new delivery based on the provided delivery details
        /// 
        ///     Example Request:
        /// 
        ///         POST Admin/Delivery
        ///         {
        ///             "Id": "delivery_id",
        ///             "Price": "100.00",
        ///             "Type": "delivery_type"
        ///         }
        ///         
        ///     Type:
        ///         mail (price 30$)
        ///         pickup (price 0$)
        ///         courier (price 15$)
        /// </remarks>
        /// <response code="200">Delivery created successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Delivery created successfully", typeof(DeliveryResponseDto))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPost("Admin/Delivery")]
        public async Task<IActionResult> CreateDeliveryAsync([FromQuery] DeliveryCreateDto deliveryModel)
        {
            return Ok(await _deliveryService.CreateDeliveryAsync(deliveryModel));
        }

        /// <summary>
        /// Edits an existing delivery
        /// </summary>
        /// <remarks>
        /// Edits an existing delivery based on the provided delivery ID and updated delivery details
        /// 
        ///     Example Request:
        /// 
        ///         PUT Admin/Delivery
        ///         {
        ///             "Id": "delivery_id",
        ///             "Price": "100.00",
        ///             "Type": "delivery_type"
        ///         }
        ///         
        ///     Type:
        ///         mail (price 30$)
        ///         pickup (price 0$)
        ///         courier (price 15$)
        /// </remarks>
        /// <response code="200">Delivery updated successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="404">Delivery not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Delivery updated successfully", typeof(DeliveryResponseDto))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Delivery not found")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPut("Admin/Delivery")]
        public async Task<IActionResult> EditDeliveryAsync([FromBody] DeliveryEditDto deliveryModel)
        {
            return Ok(await _deliveryService.EditDeliveryAsync(deliveryModel));
        }

        /// <summary>
        /// Deletes a delivery by ID
        /// </summary>
        /// <remarks>
        /// Deletes a delivery based on the provided delivery ID
        /// 
        ///     Example Request:
        /// 
        ///         DELETE Admin/Delivery
        ///         {
        ///             "id": 43
        ///         }
        /// </remarks>
        /// <response code="200">Delivery deleted successfully</response>
        /// <response code="404">Delivery not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Delivery deleted successfully", typeof(DeliveryResponseDto))]
        [SwaggerResponse(404, "Delivery not found")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpDelete("Admin/Delivery")]
        public async Task<IActionResult> DeleteDeliveryAsync([FromQuery] int id)
        {
            return Ok(await _deliveryService.DeleteDeliveryAsync(id));
        }
    }
}
