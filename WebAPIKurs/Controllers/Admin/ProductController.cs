using Application.DTOModels.Models.Admin.Pagination;
using Application.DTOModels.Models.Admin.Product;
using Application.DTOModels.Response.Admin;
using Application.Services.Interfaces.IServices;
using Application.Services.Interfaces.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPIKurs.Controllers.Admin
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IPaginationService _paginationService;

        public ProductController(IProductService productService, IPaginationService paginationService)
        {
            _productService = productService;
            _paginationService = paginationService;
        }

        /// <summary>
        /// Retrieves products with pagination and filtering
        /// </summary>
        /// <remarks>
        /// Retrieves a list of products based on specified parameters with pagination and filtering
        /// 
        ///     Example Request:
        /// 
        ///         GET Admin/Product
        ///         {
        ///            "Page": 1,
        ///            "PageSize": 10,
        ///            "SortField": Name,
        ///            "SortOrder": asc,
        ///            "Id": 43,
        ///            "Name": product_name,
        ///            "Description": product_description,
        ///            "Price": 100,
        ///            "Color": blue,
        ///            "Memory": 8GB,
        ///            "CategoryName": Phone
        ///         }
        /// 
        ///     - Page / PageSize: Page number and page size for pagination
        ///     - SortField: Field to sort the results by (e.g., Name, Price)
        ///     - SortOrder: Sort order (asc or desc)
        ///     - Id: Product ID to filter by
        ///     - Name: Product name to filter by
        ///     - Description: Product description to filter by
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
        [SwaggerResponse(200, "List of products retrieved successfully", typeof(IEnumerable<ProductResponseDto>))]
        [SwaggerResponse(400, "Invalid input data or request")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpGet("Admin/Product")]
        public async Task<IActionResult> GetProductWithPaginationAsync(ProductQueryParametersDto productModel)
        {
            return Ok(await _paginationService.GetProductWithPaginationAsync(productModel));
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <remarks>
        /// Creates a new product based on the provided product data
        /// 
        ///     Example Request:
        /// 
        ///         POST Admin/Product
        ///         {
        ///             "name": "ProductName",
        ///             "description": "ProductDescription",
        ///             "price": 100.00,
        ///             "color": "blue",
        ///             "memory": "8GB",
        ///             "categoryId": "3"
        ///         }
        ///     
        ///     categoryId: 
        ///         1 - Phone
        ///         2 - Watch 
        ///         3 - Headphones 
        ///         4 - Pixel Tablet 
        ///         5 - Accessories
        /// </remarks>
        /// <response code="200">Product created successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Product created successfully", typeof(ProductResponseDto))]
        [SwaggerResponse(400, "Invalid input data or request")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPost("Admin/Product")]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductCreateDto productModel)
        {
            return Ok(await _productService.CreateProductAsync(productModel));
        }

        /// <summary>
        /// Edits an existing product
        /// </summary>
        /// <remarks>
        /// Edits an existing product based on the provided product ID and new product data
        /// 
        ///     Example Request:
        /// 
        ///         PUT Admin/Product
        ///         {
        ///             "id": "product_id",
        ///             "name": "ProductName",
        ///             "description": "ProductDescription",
        ///             "price": 100.00,
        ///             "color": "blue",
        ///             "memory": "8GB",
        ///             "categoryId": "4"
        ///         }
        ///         
        ///     categoryId: 
        ///         1 - Phone
        ///         2 - Watch 
        ///         3 - Headphones 
        ///         4 - Pixel Tablet 
        ///         5 - Accessories
        /// </remarks>
        /// <response code="200">Product edited successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="404">Product not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Product edited successfully", typeof(ProductResponseDto))]
        [SwaggerResponse(400, "Invalid input data or request")]
        [SwaggerResponse(404, "Product not found")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPut("Admin/Product")]
        public async Task<IActionResult> EditProductAsync([FromBody] ProductEditDto productModel)
        {
            return Ok(await _productService.EditProductAsync(productModel));
        }

        /// <summary>
        /// Deletes a product by its ID
        /// </summary>
        /// <remarks>
        /// Deletes a product based on the provided product ID
        /// 
        ///     Example Request:
        /// 
        ///         DELETE Admin/Product
        ///         {
        ///            "id": 91
        ///         }
        /// </remarks>
        /// <response code="200">Product deleted successfully</response>
        /// <response code="404">Product not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Product deleted successfully", typeof(ProductResponseDto))]
        [SwaggerResponse(404, "Product not found")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpDelete("Admin/Product")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            return Ok(await _productService.DeleteProductAsync(id));
        }
    }
}
