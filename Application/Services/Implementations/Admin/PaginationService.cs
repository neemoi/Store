using Application.CustomException;
using Application.DtoModels.Models.Pagination;
using Application.DtoModels.Response.Admin;
using Application.DTOModels.Models.Admin.Pagination;
using Application.DTOModels.Response.Admin;
using Application.DTOModels.Response.User;
using Application.Services.Interfaces.IServices;
using Application.Services.UnitOfWork;
using AutoMapper;

namespace Application.Services.Implementations
{
    public class PaginationService : IPaginationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaginationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponseDto>> GetUserWithPaginationAsync(UserQueryParametersDto parametersModel)
        {
            try
            {
                var result = await _unitOfWork.PaginationRepository.GetUserWithPaginationAsync(parametersModel);

                var userResponseDto = result.Select(_mapper.Map<UserResponseDto>).ToList();

                return userResponseDto;
            }
            catch (CustomRepositoryException ex)
            {
                throw new CustomRepositoryException("Error occurred while loading data: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<IEnumerable<RoleResponseDto>> GetRoleWithPaginationAsync(RoleQueryParametersDto parametersModel)
        {
            try
            {
                var result = await _unitOfWork.PaginationRepository.GetRoleWithPaginationAsync(parametersModel);

                var roleResponseDto = result.Select(_mapper.Map<RoleResponseDto>).ToList();

                return roleResponseDto;
            }
            catch (CustomRepositoryException ex)
            {
                throw new CustomRepositoryException("Error occurred while loading data: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<IEnumerable<ProductResponseDto>> GetProductWithPaginationAsync(ProductQueryParametersDto parametersModel)
        {
            try
            {
                var result = await _unitOfWork.PaginationRepository.GetProductsWithPaginationAsync(parametersModel);


                var productResponseDto = result.Select(_mapper.Map<ProductResponseDto>).ToList();

                return productResponseDto;
            }
            catch (CustomRepositoryException ex)
            {
                throw new CustomRepositoryException("Error occurred while loading data: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<IEnumerable<PaymentResponseDto>> GetPaymentsWithPaginationAsync(PaymentQueryParametersDto parametersModel)
        {
            try
            {
                var result = await _unitOfWork.PaginationRepository.GetPaymentsWithPaginationAsync(parametersModel);


                var paymentsResponseDto = result.Select(_mapper.Map<PaymentResponseDto>).ToList();

                return paymentsResponseDto;
            }
            catch (CustomRepositoryException ex)
            {
                throw new CustomRepositoryException("Error occurred while loading data: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetCategoryWithPaginationAsync(CategoryQueryParametersDto parametersModel)
        {
            try
            {
                var result = await _unitOfWork.PaginationRepository.GetCategoryWithPaginationAsync(parametersModel);

                var categoryResponseDto = result.Select(_mapper.Map<CategoryResponseDto>).ToList();

                return categoryResponseDto;
            }
            catch (CustomRepositoryException ex)
            {
                throw new CustomRepositoryException("Error occurred while loading data: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<IEnumerable<DeliveryResponseDto>> GetDeliveryWithPaginationAsync(DeliveryQueryParametersDto parametersModel)
        {
            try
            {
                var result = await _unitOfWork.PaginationRepository.GetDeliveryWithPaginationAsync(parametersModel);

                var deliveryResponseDto = result.Select(_mapper.Map<DeliveryResponseDto>).ToList();

                return deliveryResponseDto;
            }
            catch (CustomRepositoryException ex)
            {
                throw new CustomRepositoryException("Error occurred while loading data: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<IEnumerable<UserProductResponseDto>> UserGetProductWithPaginationAsync(UserProductQueryParametersDto parametersModel)
        {
            try
            {
                var result = await _unitOfWork.PaginationRepository.UserGetProductWithPaginationAsync(parametersModel);

                var productResponseDto = result.Select(_mapper.Map<UserProductResponseDto>).ToList();

                return productResponseDto;
            }
            catch (CustomRepositoryException ex)
            {
                throw new CustomRepositoryException("Error occurred while loading data: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<IEnumerable<OrderResponseDto>> UserGetOrderWithPaginationAsync(UserOrderQueryParametersDto parametersModel, string token)
        {
            try
            {
                var result = await _unitOfWork.PaginationRepository.UserGetOrderWithPaginationAsync(parametersModel, token);

                var orderResponseDto = result.Select(_mapper.Map<OrderResponseDto>).ToList();

                return orderResponseDto;
            }
            catch (CustomRepositoryException ex)
            {
                throw new CustomRepositoryException("Error occurred while loading data: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }

        public async Task<IEnumerable<UserOrderResponseDto>> GeUserOrderWithPaginationAsync(string userId, GeUsertOrderQueryParametersDto parametersModel)
        {
            try
            {
                var result = await _unitOfWork.PaginationRepository.GeUsertOrderWithPaginationAsync(userId, parametersModel);

                var orderResponseDto = result.Select(_mapper.Map<UserOrderResponseDto>).ToList();

                return orderResponseDto;
            }
            catch (CustomRepositoryException ex)
            {
                throw new CustomRepositoryException("Error occurred while loading data: " + ex.Message, ex.ErrorCode, ex.AdditionalInfo);
            }
        }
    }
}
