using Application.DTOModels.Models.Admin.Category;
using Domain.Models;

namespace Application.Services.Interfaces.IRepository.Admin
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(Category categoryModel);

        Task<Category> EditCategoryAsync(int categorytId, CategoryEditDto categoryModel);

        Task<Category> DeleteCategoryAsync(int categorytId);
    }
}
