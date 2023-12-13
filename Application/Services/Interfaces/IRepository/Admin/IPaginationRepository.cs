using Application.DtoModels.Models.Pagination;
using Application.DtoModels.Response.Admin;
using Application.DTOModels.Models.Admin.Pagination;
using Application.DTOModels.Response.Admin;
using Application.DTOModels.Response.User;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface IPaginationRepository
    {
        Task<IEnumerable<IdentityRole>> GetRoleWithPaginationAsync(RoleQueryParametersDto parametersModel);

        Task<IEnumerable<UserResponseDto>> GetUserWithPaginationAsync(UserQueryParametersDto parametersModel);

        Task<IEnumerable<UserOrderResponseDto>> GeUsertOrderWithPaginationAsync(string userId, GeUsertOrderQueryParametersDto parametersModel);

        Task<IEnumerable<ProductResponseDto>> GetProductsWithPaginationAsync(ProductQueryParametersDto parametersModel);

        Task<IEnumerable<PaymentResponseDto>> GetPaymentsWithPaginationAsync(PaymentQueryParametersDto parametersModel);

        Task<IEnumerable<CategoryResponseDto>> GetCategoryWithPaginationAsync(CategoryQueryParametersDto parametersModel);

        Task<IEnumerable<DeliveryResponseDto>> GetDeliveryWithPaginationAsync(DeliveryQueryParametersDto parametersModel);

        Task<IEnumerable<UserProductResponseDto>> UserGetProductWithPaginationAsync(UserProductQueryParametersDto parametersModel);

        Task<IEnumerable<OrderResponseDto>> UserGetOrderWithPaginationAsync(UserOrderQueryParametersDto parametersModel, string token);
    }
}
