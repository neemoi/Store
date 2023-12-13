using Application.CustomException;
using Application.DTOModels.Models.Admin.Category;
using Application.DTOModels.Response.Admin;
using Application.Services.Interfaces.IServices.Admin;
using Application.Services.UnitOfWork;
using AutoMapper;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.Services.Implementations.Admin
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Category> _logger;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Category> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CategoryResponseDto> CreateCategoryAsync(CategoryCreateDto categoryModel)
        {
            try
            {
                _logger.LogInformation("Attempt to create an category: {@CategoryCreateDto}", categoryModel);

                var category = _mapper.Map<Category>(categoryModel);

                var result = await _unitOfWork.CategoryRepository.CreateCategoryAsync(category);

                _logger.LogInformation("Order successfully created: {@Category}", result);

                return _mapper.Map<CategoryResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when creating an category: {@CategoryCreateDto}", categoryModel);

                throw new CustomRepositoryException("Error occurred while create an category: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the category: {@CategoryCreateDto}", categoryModel);

                throw new CustomRepositoryException("Error occurred during category mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }

        public async Task<CategoryResponseDto> DeleteCategoryAsync(int categorytId)
        {
            try
            {
                _logger.LogInformation("Attempt to delete an category: {@Category}", categorytId);

                var result = await _unitOfWork.CategoryRepository.DeleteCategoryAsync(categorytId);

                _logger.LogInformation("Order successfully delete: {@Category}", result);

                return _mapper.Map<CategoryResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when delete an category: {@Category}", categorytId);

                throw new CustomRepositoryException("Error occurred while delete an category: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the category: {@Category}", categorytId);

                throw new CustomRepositoryException("Error occurred during category mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }

        public async Task<CategoryResponseDto> EditCategoryAsync(CategoryEditDto categoryModel)
        {
            try
            {
                _logger.LogInformation("Attempt to edit an category: {@CategoryEditDto}", categoryModel);

                var result = await _unitOfWork.CategoryRepository.EditCategoryAsync(categoryModel.Id, categoryModel);

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Order successfully edit: {@Category}", result);

                return _mapper.Map<CategoryResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when edit an category: {@CategoryEditDto}", categoryModel);

                throw new CustomRepositoryException("Error occurred while edit an category: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the category: {@CategoryEditDto}", categoryModel);

                throw new CustomRepositoryException("Error occurred during category mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }
    }
}
