using Application.CustomException;
using Application.DTOModels.Models.Admin.Category;
using Application.Services.Interfaces.IRepository.Admin;
using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAPIKurs;

namespace Persistance.Repository.Admin
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WebsellContext _websellContext;
        private readonly IMapper _mapper;
        private readonly ILogger<Category> _logger;

        public CategoryRepository(WebsellContext websellContext, IMapper mapper, ILogger<Category> logger)
        {
            _websellContext = websellContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            try
            {
                var result = await _websellContext.Categorys.AddAsync(category);

                if (result != null)
                {
                    await _websellContext.SaveChangesAsync();

                    return category;
                }
                else
                {
                    throw new CustomRepositoryException("Category not found", "NOT_FOUND_ERROR_CODE");
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in CategoryRepository.CreateCategoryAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<Category> DeleteCategoryAsync(int categorytId)
        {
            try
            {
                var result = await _websellContext.Categorys.FirstOrDefaultAsync(p => p.Id == categorytId);

                if (result != null)
                {
                    _websellContext.Categorys.Remove(result);

                    await _websellContext.SaveChangesAsync();

                    return result;
                }
                else
                {
                    throw new CustomRepositoryException($"Category ID ({categorytId}) not found", "NOT_FOUND_ERROR_CODE");
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in CategoryRepository.DeleteCategoryAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<Category> EditCategoryAsync(int categorytId, CategoryEditDto categoryModel)
        {
            try
            {
                var category = await _websellContext.Categorys.FirstOrDefaultAsync(p => p.Id == categorytId);

                if (category != null)
                {
                    _mapper.Map(categoryModel, category);

                    await _websellContext.SaveChangesAsync();

                    return category;
                }
                else
                {
                    throw new CustomRepositoryException($"Category ID ({categorytId}) not found", "NOT_FOUND_ERROR_CODE");
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in CategoryRepository.EditCategoryAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }
    }
}
