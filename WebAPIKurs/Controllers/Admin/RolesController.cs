using Application.DtoModels.Models.Pagination;
using Application.DtoModels.Response.Admin;
using Application.DTOModels.Models.Admin.Roles;
using Application.Services.Interfaces.IServices;
using Application.Services.Interfaces.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPIKurs.Controllers.Admin
{
    public class RolesController : Controller
    {
        private readonly IRoleService _adminRolesService;
        private readonly IPaginationService _paginationService;

        public RolesController(IRoleService adminRolesService, IPaginationService paginationService)
        {
            _adminRolesService = adminRolesService;
            _paginationService = paginationService;
        }

        /// <summary>
        /// Retrieves roles with pagination and filtering
        /// </summary>
        /// <remarks>
        /// Retrieves roles based on the specified parameters with pagination and filtering.
        /// 
        ///     Example Request:
        /// 
        ///         GET Admin/Role
        ///         {
        ///            "Page": 1,
        ///            "PageSize": 10,
        ///            "SortField": Name,
        ///            "SortOrder": asc,
        ///            "Id": role_id,
        ///            "Name": admin
        ///         }
        /// 
        ///     - Page / PageSize: Page number and page size for pagination
        ///     - SortField: Field to sort the results by (e.g., Name, Id)
        ///     - SortOrder: Sort order (asc or desc)
        ///     - Id: Role ID to filter by
        ///     - Name: Role name to filter by
        /// </remarks>
        /// <response code="200">List of roles successfully found</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "List of roles", typeof(IEnumerable<RoleResponseDto>))]
        [SwaggerResponse(400, "Invalid input data")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpGet("Admin/Role")]
        public async Task<IActionResult> GetRoleWithPaginationAsync([FromQuery] RoleQueryParametersDto parametersModel)
        {
            return Ok(await _paginationService.GetRoleWithPaginationAsync(parametersModel)) ;
        }

        /// <summary>
        /// Creates a new role
        /// </summary>
        /// <remarks>
        /// Creates a new role based on the provided role name
        /// 
        ///     Example Request:
        /// 
        ///         POST Admin/Role
        ///         {
        ///           "roleName": "NewRoleName"
        ///         }
        /// </remarks>
        /// <response code="200">Role created successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Role created successfully", typeof(RoleResponseDto))]
        [SwaggerResponse(400, "Invalid input data or request")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPost("Admin/Role")]
        public async Task<IActionResult> CreateRoleAsync([FromBody] string name)
        {
            return Ok(await _adminRolesService.CreateRoleAsync(name));
        }

        /// <summary>
        /// Edits a role by its ID
        /// </summary>
        /// <remarks>
        /// Edits a role based on the provided role ID and new name
        /// 
        ///     Example Request:
        /// 
        ///         PUT Admin/Role/
        ///         {
        ///           "id": "d968d618-f044-4a8c-a1ed-164133e36da4",
        ///           "name": "NewRoleName"
        ///         }
        /// </remarks>
        /// <response code="200">Role updated successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="404">Role not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Role updated successfully", typeof(RoleResponseDto))]
        [SwaggerResponse(400, "Invalid input data or request")]
        [SwaggerResponse(404, "Role not found")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpPut("Admin/Role")]
        public async Task<IActionResult> EditRoleByIdAsync(EditRoleByIdDto editModel)
        {
            return Ok(await _adminRolesService.EditRoleByIdAsync(editModel));
        }

        /// <summary>
        /// Deletes a role by its ID
        /// </summary>
        /// <remarks>
        /// Deletes a role based on the provided role ID
        /// 
        ///     Example Request:
        /// 
        ///         DELETE 
        ///         {
        ///             "id": "d968d618-f044-4a8c-a1ed-164133e36da4"
        ///         }
        /// </remarks>
        /// <response code="200">Role deleted successfully</response>
        /// <response code="400">Invalid input data or request</response>
        /// <response code="404">Role not found</response>
        /// <response code="500">Internal server error</response>
        [SwaggerResponse(200, "Role deleted successfully", typeof(RoleResponseDto))]
        [SwaggerResponse(400, "Invalid input data or request")]
        [SwaggerResponse(404, "Role not found")]
        [SwaggerResponse(500, "Internal server error")]
        [HttpDelete("Admin/Role")]
        public async Task<IActionResult> DeleteRoleAsync(Guid id)
        {
            return Ok(await _adminRolesService.DeleteRoleAsync(id));
        }
    }
}
