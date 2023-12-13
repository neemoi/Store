using Application.DTOModels.Models.Admin.Product;
using WebAPIKurs;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface IProductRepository
    {
        Task<Product> CreateProductAsync(Product productModel);

        Task<Product> EditProductAsync(int productId, ProductEditDto productModel);

        Task<Product> DeleteProductAsync(int productId);
    }
}
