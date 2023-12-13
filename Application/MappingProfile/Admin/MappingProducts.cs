using AutoMapper;
using WebAPIKurs;
using Application.DTOModels.Response.Admin;
using Application.DTOModels.Models.Admin.Product;
using Application.DTOModels.Response.User;

namespace Application.MappingProfile.Admin
{
    public class MappingProducts : Profile
    {
        public MappingProducts()
        {
            CreateMap<Product, ProductCreateDto>();
            CreateMap<ProductCreateDto, Product>();

            CreateMap<Product, ProductEditDto>();
            CreateMap<ProductEditDto, Product>();

            CreateMap<Product, ProductResponseDto>();
            CreateMap<Product, UserProductResponseDto>();
        }
    }
}