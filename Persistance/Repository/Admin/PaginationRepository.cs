using Application.CustomException;
using Application.DtoModels.Models.Pagination;
using Application.DtoModels.Response.Admin;
using Application.DTOModels.Models.Admin.Pagination;
using Application.DTOModels.Response.Admin;
using Application.DTOModels.Response.User;
using Application.Services.Interfaces.IRepository.Admin;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPIKurs;

namespace Persistance.Repository.Admin
{
    public class PaginationRepository : IPaginationRepository
    {
        private readonly WebsellContext _websellContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaginationRepository(WebsellContext websellContext, RoleManager<IdentityRole> roleManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _websellContext = websellContext;
            _roleManager = roleManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<IdentityRole>> GetRoleWithPaginationAsync(RoleQueryParametersDto parametersModel)
        {
            try
            {
                var roles = BuildGetRoleProductQuery(parametersModel);

                return await roles
                    .Skip((parametersModel.Page - 1) * parametersModel.PageSize)
                    .Take(parametersModel.PageSize)
                    .ToListAsync(); ;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<IEnumerable<UserResponseDto>> GetUserWithPaginationAsync(UserQueryParametersDto parametersModel)
        {
            try
            {
                var usersQuery = _websellContext.Users
                    .Join(_websellContext.UserRoles,
                        user => user.Id,
                        userRole => userRole.UserId,
                        (user, userRole) => new { User = user, userRole.RoleId })
                    .Join(_websellContext.Roles,
                        userRole => userRole.RoleId,
                        role => role.Id,
                        (userRole, role) => new { userRole.User, Role = role.Name })
                    .AsQueryable();

                if (!string.IsNullOrEmpty(parametersModel.SortField))
                {
                    parametersModel.SortField = char.ToUpper(parametersModel.SortField[0]) + parametersModel.SortField.Substring(1); //changing the case of the first letter to the uppercase

                    usersQuery = parametersModel.SortOrder.ToUpper() == "DESC"
                        ? usersQuery.OrderByDescending(u => EF.Property<object>(u.User, parametersModel.SortField))
                        : usersQuery.OrderBy(u => EF.Property<object>(u.User, parametersModel.SortField));
                }

                if (!string.IsNullOrEmpty(parametersModel.Id))
                {
                    usersQuery = usersQuery.Where(u => u.User.Id.Contains(parametersModel.Id));
                }
                if (!string.IsNullOrEmpty(parametersModel.UserName))
                {
                    usersQuery = usersQuery.Where(u => u.User.UserName.Contains(parametersModel.UserName));
                }
                if (!string.IsNullOrEmpty(parametersModel.Email))
                {
                    usersQuery = usersQuery.Where(u => u.User.Email.Contains(parametersModel.Email));
                }
                if (!string.IsNullOrEmpty(parametersModel.PhoneNumber))
                {
                    usersQuery = usersQuery.Where(u => u.User.PhoneNumber.Contains(parametersModel.PhoneNumber));
                }
                if (!string.IsNullOrEmpty(parametersModel.State))
                {
                    usersQuery = usersQuery.Where(u => u.User.State.Contains(parametersModel.State));
                }
                if (!string.IsNullOrEmpty(parametersModel.City))
                {
                    usersQuery = usersQuery.Where(u => u.User.City.Contains(parametersModel.City));
                }
                if (!string.IsNullOrEmpty(parametersModel.Address))
                {
                    usersQuery = usersQuery.Where(u => u.User.Address.Contains(parametersModel.Address));
                }

                var users = await usersQuery
                    .Skip((parametersModel.Page - 1) * parametersModel.PageSize)
                    .Take(parametersModel.PageSize)
                    .ToListAsync();

                var userResponseDto = users.Select(user =>
                {
                    var userResponseDto = _mapper.Map<UserResponseDto>(user.User);
                    userResponseDto.Role = user.Role;

                    return userResponseDto;

                }).ToList();

                return userResponseDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<IEnumerable<ProductResponseDto>> GetProductsWithPaginationAsync(ProductQueryParametersDto parametersModel)
        {
            try
            {
                var productsQuery = BuildProductQuery(parametersModel);

                var products = await productsQuery
                    .Skip((parametersModel.Page - 1) * parametersModel.PageSize)
                    .Take(parametersModel.PageSize)
                    .ToListAsync();

                return products.Select(_mapper.Map<ProductResponseDto>).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<IEnumerable<PaymentResponseDto>> GetPaymentsWithPaginationAsync(PaymentQueryParametersDto parametersModel)
        {
            try
            {
                var paymentsQuery = BuildPaymentQuery(parametersModel);

                var payments = await paymentsQuery
                    .Skip((parametersModel.Page - 1) * parametersModel.PageSize)
                    .Take(parametersModel.PageSize)
                    .ToListAsync();

                return payments.Select(_mapper.Map<PaymentResponseDto>).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetCategoryWithPaginationAsync(CategoryQueryParametersDto parametersModel)
        {
            try
            {
                var categoryQuery = BuildCategoryQuery(parametersModel);

                var categorys = await categoryQuery
                    .Skip((parametersModel.Page - 1) * parametersModel.PageSize)
                    .Take(parametersModel.PageSize)
                    .ToListAsync();

                return categorys.Select(_mapper.Map<CategoryResponseDto>).ToList(); ;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<IEnumerable<DeliveryResponseDto>> GetDeliveryWithPaginationAsync(DeliveryQueryParametersDto parametersModel)
        {
            try
            {
                var deliveryQuery = BuildDeliveryQuery(parametersModel);

                var deliverys = await deliveryQuery
                    .Skip((parametersModel.Page - 1) * parametersModel.PageSize)
                    .Take(parametersModel.PageSize)
                    .ToListAsync();

                return deliverys.Select(_mapper.Map<DeliveryResponseDto>).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<IEnumerable<UserProductResponseDto>> UserGetProductWithPaginationAsync(UserProductQueryParametersDto parametersModel)
        {
            try
            {
                var productsQuery = BuildUserGetProductQuery(parametersModel);

                var products = await productsQuery
                    .Skip((parametersModel.Page - 1) * parametersModel.PageSize)
                    .Take(parametersModel.PageSize)
                    .ToListAsync();

                return products.Select(_mapper.Map<UserProductResponseDto>).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<IEnumerable<OrderResponseDto>> UserGetOrderWithPaginationAsync(UserOrderQueryParametersDto parametersModel, string token)
        {
            try
            {
                var ordersQuery = BuildUserGetOrderQuery(parametersModel, token);

                var orders = await ordersQuery
                    .Skip((parametersModel.Page - 1) * parametersModel.PageSize)
                    .Take(parametersModel.PageSize)
                    .ToListAsync();

                var orderResponseList = new List<OrderResponseDto>();

                foreach (var order in orders)
                {
                    await LoadOrderDetailsAsync(order);

                    var orderResponse = _mapper.Map<OrderResponseDto>(order);
                    orderResponseList.Add(orderResponse);
                }

                return orderResponseList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<IEnumerable<UserOrderResponseDto>> GeUsertOrderWithPaginationAsync(string userId, GeUsertOrderQueryParametersDto parametersModel)
        {
            try
            {
                var ordersQuery = BuildGetUserOrderQuery(userId, parametersModel);

                var orders = await ordersQuery
                    .Skip((parametersModel.Page - 1) * parametersModel.PageSize)
                    .Take(parametersModel.PageSize)
                    .ToListAsync();

                var orderResponseList = new List<UserOrderResponseDto>();

                foreach (var order in orders)
                {
                    await LoadOrderDetailsAsync(order);

                    var orderResponse = _mapper.Map<UserOrderResponseDto>(order);
                    orderResponseList.Add(orderResponse);
                }

                return orderResponseList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        #region PrivateMethodProduct

        private IQueryable<Product> BuildProductQuery(ProductQueryParametersDto parametersModel)
        {
            var productsQuery = _websellContext.Products
                .AsQueryable();

            productsQuery = ApplyProductFilters(productsQuery, parametersModel);

            if (!string.IsNullOrEmpty(parametersModel.SortField))
            {
                productsQuery = ApplySorting(productsQuery, parametersModel.SortField, parametersModel.SortOrder);
            }

            return productsQuery;
        }

        private IQueryable<Product> ApplyProductFilters(IQueryable<Product> productsQuery, ProductQueryParametersDto parametersModel)
        {
            if (!string.IsNullOrEmpty(parametersModel.Id))
            {
                productsQuery = productsQuery.Where(p => p.Id.ToString().Contains(parametersModel.Id));
            }
            if (!string.IsNullOrEmpty(parametersModel.Name))
            {
                productsQuery = productsQuery.Where(p => p.Name.Contains(parametersModel.Name));
            }
            if (!string.IsNullOrEmpty(parametersModel.Description))
            {
                productsQuery = productsQuery.Where(p => p.Description.Contains(parametersModel.Description));
            }
            if (!string.IsNullOrEmpty(parametersModel.Price))
            {
                productsQuery = productsQuery.Where(p => p.Price.ToString().Contains(parametersModel.Price));
            }
            if (!string.IsNullOrEmpty(parametersModel.Color))
            {
                productsQuery = productsQuery.Where(p => p.Color.Contains(parametersModel.Color));
            }
            if (!string.IsNullOrEmpty(parametersModel.Memory))
            {
                productsQuery = productsQuery.Where(p => p.Memory == parametersModel.Memory);
            }
            if (!string.IsNullOrEmpty(parametersModel.CategoryName))
            {
                productsQuery = productsQuery.Where(p => p.Category.Name == parametersModel.CategoryName);
            }

            return productsQuery;
        }

        #endregion

        #region PrivateMethodPayments

        private IQueryable<Payment> BuildPaymentQuery(PaymentQueryParametersDto parametersModel)
        {
            var paymentsQuery = _websellContext.Payments.AsQueryable();

            paymentsQuery = ApplyPaymentFilters(paymentsQuery, parametersModel);

            if (!string.IsNullOrEmpty(parametersModel.SortField))
            {
                paymentsQuery = ApplySorting(paymentsQuery, parametersModel.SortField, parametersModel.SortOrder);
            }

            return paymentsQuery;
        }


        private IQueryable<Payment> ApplyPaymentFilters(IQueryable<Payment> paymentsQuery, PaymentQueryParametersDto parametersModel)
        {
            if (!string.IsNullOrEmpty(parametersModel.Id))
            {
                paymentsQuery = paymentsQuery.Where(p => p.Id.ToString().Contains(parametersModel.Id));
            }
            if (!string.IsNullOrEmpty(parametersModel.Amount))
            {
                paymentsQuery = paymentsQuery.Where(p => p.Amount.ToString().Contains(parametersModel.Amount));
            }
            if (!string.IsNullOrEmpty(parametersModel.Type))
            {
                paymentsQuery = paymentsQuery.Where(p => p.Type == parametersModel.Type);
            }

            return paymentsQuery;
        }

        #endregion

        #region PrivateMethodCategory

        private IQueryable<Category> BuildCategoryQuery(CategoryQueryParametersDto parametersModel)
        {
            var categoryQuery = _websellContext.Categorys.AsQueryable();

            categoryQuery = ApplyCategoryFilters(categoryQuery, parametersModel);

            if (!string.IsNullOrEmpty(parametersModel.SortField))
            {
                parametersModel.SortField = char.ToUpper(parametersModel.SortField[0]) + parametersModel.SortField.Substring(1);

                categoryQuery = ApplySorting(categoryQuery, parametersModel.SortField, parametersModel.SortOrder);
            }

            return categoryQuery;
        }

        private IQueryable<Category> ApplyCategoryFilters(IQueryable<Category> categoryQuery, CategoryQueryParametersDto parametersModel)
        {
            if (!string.IsNullOrEmpty(parametersModel.Id))
            {
                categoryQuery = categoryQuery.Where(p => p.Id.ToString().Contains(parametersModel.Id));
            }
            if (!string.IsNullOrEmpty(parametersModel.Description))
            {
                categoryQuery = categoryQuery.Where(p => p.Description == parametersModel.Description);
            }
            if (!string.IsNullOrEmpty(parametersModel.Name))
            {
                categoryQuery = categoryQuery.Where(p => p.Name == parametersModel.Name);
            }

            return categoryQuery;
        }

        #endregion

        #region PrivateMethodDelivery

        private IQueryable<Delivery> BuildDeliveryQuery(DeliveryQueryParametersDto parametersModel)
        {
            var deliveryQuery = _websellContext.Deliveries.AsQueryable();

            deliveryQuery = ApplyDeliveryFilters(deliveryQuery, parametersModel);

            if (!string.IsNullOrEmpty(parametersModel.SortField))
            {
                parametersModel.SortField = char.ToUpper(parametersModel.SortField[0]) + parametersModel.SortField.Substring(1);

                deliveryQuery = ApplySorting(deliveryQuery, parametersModel.SortField, parametersModel.SortOrder);
            }

            return deliveryQuery;
        }

        private IQueryable<Delivery> ApplyDeliveryFilters(IQueryable<Delivery> deliveryQuery, DeliveryQueryParametersDto parametersModel)
        {
            if (!string.IsNullOrEmpty(parametersModel.Id))
            {
                deliveryQuery = deliveryQuery.Where(p => p.Id.ToString().Contains(parametersModel.Id));
            }
            if (!string.IsNullOrEmpty(parametersModel.Price))
            {
                deliveryQuery = deliveryQuery.Where(p => p.Price.ToString().Contains(parametersModel.Price));
            }
            if (!string.IsNullOrEmpty(parametersModel.Type))
            {
                deliveryQuery = deliveryQuery.Where(p => p.Type == parametersModel.Type);
            }

            return deliveryQuery;
        }

        #endregion

        #region PrivateMethodUserGetProduct

        private IQueryable<Product> BuildUserGetProductQuery(UserProductQueryParametersDto parametersModel)
        {
            var productsQuery = _websellContext.Products
               .Include(p => p.Category)
               .AsQueryable();

            productsQuery = ApplyUserGetProductFilters(productsQuery, parametersModel);

            if (!string.IsNullOrEmpty(parametersModel.SortField))
            {
                productsQuery = ApplySorting(productsQuery, parametersModel.SortField, parametersModel.SortOrder);
            }

            return productsQuery;
        }

        private IQueryable<Product> ApplyUserGetProductFilters(IQueryable<Product> productsQuery, UserProductQueryParametersDto parametersModel)
        {
            if (!string.IsNullOrEmpty(parametersModel.ProductId))
            {
                productsQuery = productsQuery.Where(p => p.Id.ToString().Contains(parametersModel.ProductId));
            }
            if (!string.IsNullOrEmpty(parametersModel.Name))    
            {
                productsQuery = productsQuery.Where(p => p.Name.Contains(parametersModel.Name));
            }
            if (!string.IsNullOrEmpty(parametersModel.Price))
            {
                productsQuery = productsQuery.Where(p => p.Price.ToString().Contains(parametersModel.Price));
            }
            if (!string.IsNullOrEmpty(parametersModel.Color))
            {
                productsQuery = productsQuery.Where(p => p.Color == parametersModel.Color);
            }
            if (!string.IsNullOrEmpty(parametersModel.Memory))
            {
                productsQuery = productsQuery.Where(p => p.Memory == parametersModel.Memory);
            }
            if (!string.IsNullOrEmpty(parametersModel.CategoryName))
            {
                productsQuery = productsQuery.Where(p => p.Category.Name == parametersModel.CategoryName);
            }

            return productsQuery;
        }

        #endregion

        #region PrivateMethodGetRole

        private IQueryable<IdentityRole> BuildGetRoleProductQuery(RoleQueryParametersDto parametersModel)
        {
            var rolesQuery = _roleManager.Roles.AsQueryable();

            rolesQuery = ApplyGetRoleFilters(rolesQuery, parametersModel);

            if (!string.IsNullOrEmpty(parametersModel.SortField))
            {
                rolesQuery = ApplySorting(rolesQuery, parametersModel.SortField, parametersModel.SortOrder);
            }

            return rolesQuery;
        }

        private IQueryable<IdentityRole> ApplyGetRoleFilters(IQueryable<IdentityRole> rolesQuery, RoleQueryParametersDto parametersModel)
        {
            if (!string.IsNullOrEmpty(parametersModel.Id))
            {
                rolesQuery = rolesQuery.Where(p => p.Id.Contains(parametersModel.Id));
            }
            if (!string.IsNullOrEmpty(parametersModel.Name))
            {
                rolesQuery = rolesQuery.Where(r => r.Name.Contains(parametersModel.Name));
            }

            return rolesQuery;
        }

        #endregion

        #region PrivateMethodUserGetOrder

        private IQueryable<Order> BuildUserGetOrderQuery(UserOrderQueryParametersDto parametersModel, string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jsonToken == null)
            {
                throw new CustomRepositoryException("Invalid token format", "INVALID_TOKEN_FORMAT_ERROR");
            }

            var userId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value
                ?? throw new CustomRepositoryException("User ID not found in token", "INVALID_TOKEN_ERROR");

            var userOrders = _websellContext.Orders
                .Include(p => p.Orderitems)
                .Where(order => order.UserId == userId);

            userOrders = ApplyUserGetOrderFilters(userOrders, parametersModel);

            if (!string.IsNullOrEmpty(parametersModel.SortField))
            {
                userOrders = ApplySorting(userOrders, parametersModel.SortField, parametersModel.SortOrder);
            }

            return userOrders;
        }

        private IQueryable<Order> ApplyUserGetOrderFilters(IQueryable<Order> ordersQuery, UserOrderQueryParametersDto parametersModel)
        {
            if (!string.IsNullOrEmpty(parametersModel.OrderId) && ordersQuery != null)
            {
                ordersQuery = ordersQuery.Where(p => p.Id.ToString().Contains(parametersModel.OrderId));
            }
            if (!string.IsNullOrEmpty(parametersModel.CreateAt))
            {
                ordersQuery = ordersQuery.Where(p => p.CreatedAt.ToString().Contains(parametersModel.CreateAt));
            }
            if (!string.IsNullOrEmpty(parametersModel.Status))
            {
                ordersQuery = ordersQuery.Where(p => p.Status == parametersModel.Status);
            }
            if (!string.IsNullOrEmpty(parametersModel.TotalPrice))
            {
                ordersQuery = ordersQuery.Where(p => p.TotalPrice.ToString().Contains(parametersModel.TotalPrice));
            }
            if (!string.IsNullOrEmpty(parametersModel.DeliveryId))
            {
                ordersQuery = ordersQuery.Where(p => p.DeliverId.ToString().Contains(parametersModel.DeliveryId));
            }
            if (!string.IsNullOrEmpty(parametersModel.PaymentId))
            {
                ordersQuery = ordersQuery.Where(p => p.PaymentId.ToString().Contains(parametersModel.PaymentId));
            }

            return ordersQuery;
        }

        #endregion

        #region PrivateMethodGetUserOrder

        private IQueryable<Order> BuildGetUserOrderQuery(string userId, GeUsertOrderQueryParametersDto parametersModel)
        {
            var userOrders = _websellContext.Orders
                .Include(p => p.Orderitems)
                .Where(order => order.UserId == userId);

            userOrders = ApplyGetUserOrderFilters(userOrders, parametersModel);

            if (!string.IsNullOrEmpty(parametersModel.SortField))
            {
                userOrders = ApplySorting(userOrders, parametersModel.SortField, parametersModel.SortOrder);
            }

            return userOrders;
        }

        public IQueryable<Order> ApplyGetUserOrderFilters(IQueryable<Order> ordersQuery, GeUsertOrderQueryParametersDto parametersModel)
        {
            if (!string.IsNullOrEmpty(parametersModel.UserId))
            {
                ordersQuery = ordersQuery.Where(p => p.UserId == parametersModel.UserId);
            }
            if (!string.IsNullOrEmpty(parametersModel.CreateAt))
            {
                ordersQuery = ordersQuery.Where(p => p.CreatedAt.ToString().Contains(parametersModel.CreateAt));
            }
            if (!string.IsNullOrEmpty(parametersModel.Status))
            {
                ordersQuery = ordersQuery.Where(p => p.Status == parametersModel.Status);
            }
            if (!string.IsNullOrEmpty(parametersModel.TotalPrice))
            {
                ordersQuery = ordersQuery.Where(p => p.TotalPrice.ToString().Contains(parametersModel.TotalPrice));
            }
            if (!string.IsNullOrEmpty(parametersModel.DeliveryId))
            {
                ordersQuery = ordersQuery.Where(p => p.DeliverId.ToString().Contains(parametersModel.DeliveryId));
            }
            if (!string.IsNullOrEmpty(parametersModel.PaymentId))
            {
                ordersQuery = ordersQuery.Where(p => p.PaymentId.ToString().Contains(parametersModel.PaymentId));
            }
            if (!string.IsNullOrEmpty(parametersModel.Price))
            {
                ordersQuery = ordersQuery.Where(p => p.Orderitems.Any(oi => oi.Product.Price.ToString().Contains(parametersModel.Price)));
            }
            if (!string.IsNullOrEmpty(parametersModel.Color))
            {
                ordersQuery = ordersQuery.Where(p => p.Orderitems.Any(oi => oi.Product.Color.Contains(parametersModel.Color)));
            }
            if (!string.IsNullOrEmpty(parametersModel.Memory))
            {
                ordersQuery = ordersQuery.Where(p => p.Orderitems.Any(oi => oi.Product.Memory.Contains(parametersModel.Memory)));
            }

            return ordersQuery;
        }


        #endregion

        private async Task LoadOrderDetailsAsync(Order order)
        {
            await _websellContext.Entry(order)
                .Collection(o => o.Orderitems)
                .Query()
                .Include(oi => oi.Product)
                .LoadAsync();

            await _websellContext.Entry(order)
                .Reference(o => o.Payments)
                .LoadAsync();

            await _websellContext.Entry(order)
                .Reference(o => o.Deliveries)
                .LoadAsync();

            var productPrices = order.Orderitems.Select(oi => oi.Product.Price).ToList() ?? throw new Exception("Price name not found");
            var colorList = order.Orderitems.Select(oi => oi.Product.Color).ToList() ?? throw new Exception("Color name not found");
            var memoryList = order.Orderitems.Select(oi => oi.Product.Memory).ToList() ?? throw new Exception("Memory name not found");
            var nameList = order.Orderitems.Select(oi => oi.Product.Name).ToList() ?? throw new Exception("Product name not found");

            var orderResponse = _mapper.Map<OrderResponseDto>(order);
            orderResponse.ListProductPrices = productPrices;
            orderResponse.ListProductName = nameList;
            orderResponse.ListProductColor = colorList;
            orderResponse.ListProductMemory = memoryList;
        }

        private IQueryable<T> ApplySorting<T>(IQueryable<T> query, string sortField, string sortOrder)
        {
            if (!string.IsNullOrEmpty(sortField))
            {
                sortField = char.ToUpper(sortField[0]) + sortField.Substring(1); //changing the case of the first letter to the uppercase

                return sortOrder.ToUpper() == "DESC"
                    ? query.OrderByDescending(p => EF.Property<object>(p, sortField))
                    : query.OrderBy(p => EF.Property<object>(p, sortField));
            }

            return query;
        }
    }
}