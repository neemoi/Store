using Application.MappingProfile.Admin;
using Application.Services.Implementations;
using Application.Services.Implementations.Admin;
using Application.Services.Implementations.User;
using Application.Services.Interfaces.IRepository.Admin;
using Application.Services.Interfaces.IRepository.User;
using Application.Services.Interfaces.IServices;
using Application.Services.Interfaces.IServices.Admin;
using Application.Services.Interfaces.IServices.User;
using Application.Services.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistance.Repository.Admin;
using Persistance.Repository.User;
using Persistance.UnitOfWork;
using WebAPIKurs.CustomExceptionMiddleware;

namespace WebAPIKurs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<WebsellContext>(options =>
            {
                options.UseMySql("server=localhost;database=WebSell;uid=admin;pwd=admin",
                    ServerVersion.Parse("8.0.33-mysql"));
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddLogging(builder =>
            {
                builder.AddConsole(); 
            });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebAPI",
                });

                options.IncludeXmlComments("APIDocumentation.xml");
            });

            //Registering Scoped Services
            builder.Services.AddAutoMapper(typeof(MappingAccount), typeof(MappingRoles), typeof(MappingUsers), 
                typeof(MappingProducts), typeof(MappingPayments), typeof(MappingCategory),
                typeof(MappingDelivery), typeof(MappingOrder));

            //Registering Scoped Services
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<UserManager<CustomUser>>();
            builder.Services.AddScoped<UserManager<CustomUser>, UserManager<CustomUser>>();
            builder.Services.AddScoped<IAccountService, AuthorizationService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IPaginationService, PaginationService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IDeliveryService, DeliveryService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IUserOrderService, UserOrderService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserService, UserService>();

            //Registering Scoped Repositories
            builder.Services.AddScoped<IPaginationRepository, PaginationRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IPaymentsRepository, PaymentRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IUserOrderRepository, UserOrderRepository>();
            builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
            builder.Services.AddScoped<IRoleRepostitory, RoleRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            //Identity Configuration
            builder.Services.AddIdentity<CustomUser, IdentityRole>()
            .AddEntityFrameworkStores<WebsellContext>()
            .AddRoles<IdentityRole>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
                });
            }

            //GlobalException
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}