using Application.DTOModels.Models.Admin.Product;
using Application.DTOModels.Response.Admin;

namespace Application.Services.Interfaces.IServices.Admin
{
    public interface IProductService
    {
        Task<ProductResponseDto> CreateProductAsync(ProductCreateDto productModel);

        Task<ProductResponseDto> EditProductAsync(ProductEditDto productModel);

        Task<ProductResponseDto> DeleteProductAsync(int productId);
    }
}
