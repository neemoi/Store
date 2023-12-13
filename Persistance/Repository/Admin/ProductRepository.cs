using Application.CustomException;
using Application.DTOModels.Models.Admin.Product;
using Application.Services.Interfaces.IRepository.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using WebAPIKurs;

namespace Persistance.Repository.Admin
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebsellContext _websellContext;
        private readonly IMapper _mapper;
        private readonly ILogger<Product> _logger;

        public ProductRepository(WebsellContext websellContext, IMapper mapper, ILogger<Product> logger)
        {
            _websellContext = websellContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            try
            {
                var result = await _websellContext.Products.AddAsync(product);

                if (result != null)
                {
                    await _websellContext.SaveChangesAsync();

                    return product;
                }
                else
                {
                    throw new CustomRepositoryException("Product not found", "NOT_FOUND_ERROR_CODE");
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in ProductRepository.CreateProductAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            try
            {
                var result = await _websellContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

                if (result != null)
                {
                    _websellContext.Products.Remove(result);

                    await _websellContext.SaveChangesAsync();

                    return result;
                }
                else
                {
                    throw new CustomRepositoryException($"Product ID ({productId}) not found", "NOT_FOUND_ERROR_CODE");
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in ProductRepository.DeleteProductAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<Product> EditProductAsync(int productId, ProductEditDto productModel)
        {
            try
            {
                var product = await _websellContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

                if (product != null)
                {
                    _mapper.Map(productModel, product);

                    await _websellContext.SaveChangesAsync();

                    return product;
                }
                else
                {
                    throw new CustomRepositoryException($"Product ID ({productId}) not found", "NOT_FOUND_ERROR_CODE");
                }
            }
            catch (CustomRepositoryException ex)
            {
                _logger.LogError(ex, "Error in ProductRepository.EditProductAsync: ", ex.Message);

                throw new CustomRepositoryException(ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }
    }
}
