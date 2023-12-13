using Application.CustomException;
using Application.DTOModels.Models.Admin.Product;
using Application.DTOModels.Response.Admin;
using Application.DTOModels.Response.User;
using Application.Services.Interfaces.IServices.Admin;
using Application.Services.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;
using WebAPIKurs;

namespace Application.Services.Implementations.Admin
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<Product> _logger;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Product> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductResponseDto> CreateProductAsync(ProductCreateDto productModel)
        {
            try
            {
                _logger.LogInformation("Attempt to create an product: {@ProductCreateDto}", productModel);
                
                var product = _mapper.Map<Product>(productModel);

                var result = await _unitOfWork.ProductRepository.CreateProductAsync(product);

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Product successfully create: {@Product}", result);

                return _mapper.Map<ProductResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when create an product: {@ProductCreateDto}", productModel);

                throw new CustomRepositoryException("Error occurred while create an product: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the product: {@ProductCreateDto}", productModel);

                throw new CustomRepositoryException("Error occurred during product mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }

        public async Task<ProductResponseDto> DeleteProductAsync(int productId)
        {
            try
            {
                _logger.LogInformation("Attempt to delete an product: {@Product}", productId);

                var result = await _unitOfWork.ProductRepository.DeleteProductAsync(productId);

                _logger.LogInformation("Product successfully deleted: {@Product}", result);

                return _mapper.Map<ProductResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when delete an product: {@Product}", productId);

                throw new CustomRepositoryException("Error occurred while delete an product: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the product: {@Product}", productId);

                throw new CustomRepositoryException("Error occurred during product mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }

        public async Task<ProductResponseDto> EditProductAsync(ProductEditDto productModel)
        {
            try
            {
                _logger.LogInformation("Attempt to edit an product: {@ProductEditDto}", productModel);

                var result = await _unitOfWork.ProductRepository.EditProductAsync(productModel.Id, productModel);

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Product successfully edit: {@Product}", result);

                return _mapper.Map<ProductResponseDto>(result);
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error when edit an product: {@ProductEditDto}", productModel);

                throw new CustomRepositoryException("Error occurred while edit an product: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error when mapping the product: {@ProductEditDto}", productModel);

                throw new CustomRepositoryException("Error occurred during product mapping", "MAPPING_ERROR_CODE", ex.Message);
            }
        }
    }
}
