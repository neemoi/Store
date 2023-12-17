using Application.DTOModels.Models.Admin.Pagination;
using Application.Services.Interfaces.IServices.Admin;
using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Application.DTOModels.Models.Admin.Category;
using Microsoft.AspNetCore.Authorization;
using Application.DTOModels.Response.Admin;
using Swashbuckle.AspNetCore.Annotations;
using Domain.Models;

namespace WebAPIKurs.Controllers.Admin
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPaginationService _paginationService;

        public CategoryController(ICategoryService categoryService, IPaginationService paginationService)
        {
            _categoryService = categoryService;
            _paginationService = paginationService;
        }

        /// <summary>
        /// Retrieves categories with pagination and filtering
        /// </summary>
        /// <remarks>
        /// Retrieves a list of categories based on specified parameters with pagination and filtering
        /// 
        ///     Example Request:
        /// 
        ///         GET Admin/Category
        ///         {
        ///             "Page": 1,
        ///             "PageSize": 10,
        ///             "SortField": "Id",
        ///             "SortOrder": "asc",
        ///             "Id": "category_id",
        ///             "Description": "category_description",
        ///             "Name": "category_name"
        ///         }
        /// 
        ///     - Page / PageSize: Page number and page size for pagination
        ///     - SortField: Field to sort the results by (e.g., Id, Description)
        ///     - SortOrder: Sort order (asc or desc)
        ///     - Id: Category ID to filter by
        ///     - Description: Category description to filter by
        ///     - Name: Category name to filter by
        ///     
        ///     categoryId: 
        ///         1 - Phone
        ///         2 - Watch 
        ///         3 - Headphones 
        ///         4 - Pixel Tablet 
        ///         5 - Accessories
        /// </remarks>
        /// <response code="200">List of categories retrieved successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "List of categories", typeof(IEnumerable<CategoryResponseDto>))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpGet("Admin/Category")]
        public async Task<IActionResult> GetCategoryWithPaginationAsync([FromQuery] CategoryQueryParametersDto productModel)
        {
            return Ok(await _paginationService.GetCategoryWithPaginationAsync(productModel));
        }

        /// <summary>
        /// Creates a new category
        /// </summary>
        /// <remarks>
        /// Creates a new category based on the provided category data
        /// 
        ///     Example Request:
        /// 
        ///         POST Admin/Category
        ///         {
        ///             "Description": "category_description",
        ///             "Name": "category_name"
        ///         }
        /// </remarks>
        /// <response code="200">Category created successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Category created successfully", typeof(CategoryResponseDto))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPost("Admin/Category")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryCreateDto productModel)
        {
            return Ok(await _categoryService.CreateCategoryAsync(productModel));
        }

        /// <summary>
        /// Edits an existing category
        /// </summary>
        /// <remarks>
        /// Edits an existing category based on the provided category ID and updated data
        /// 
        ///     Example Request:
        /// 
        ///         PUT Admin/Category
        ///         {
        ///             "Id": "updated_category_id",
        ///             "Description": "updated_category_description",
        ///             "Name": "updated_category_name"
        ///         }
        /// </remarks>
        /// <response code="200">Category updated successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="404">Category not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Category updated successfully", typeof(CategoryResponseDto))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(404, "Category not found")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPut("Admin/Category")]
        public async Task<IActionResult> EditCategoryAsync([FromBody] CategoryEditDto productModel)
        {
            return Ok(await _categoryService.EditCategoryAsync(productModel));
        }

        /// <summary>
        /// Deletes a category by its ID
        /// </summary>
        /// <remarks>
        /// Deletes a category based on the provided category ID
        /// 
        ///     Example Request:
        /// 
        ///         DELETE Admin/Category
        ///         {
        ///             "id": 64
        ///         }
        /// </remarks>
        /// <response code="200">Category deleted successfully</response>
        /// <response code="404">Category not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Category deleted successfully", typeof(CategoryResponseDto))]
        [SwaggerResponse(404, "Category not found")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpDelete("Admin/Category/")]
        public async Task<IActionResult> DeleteCategoryAsync([FromQuery] int id)
        {
            return Ok(await _categoryService.DeleteCategoryAsync(id));
        }
    }
}
