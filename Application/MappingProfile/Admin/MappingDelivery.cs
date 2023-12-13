using Application.DTOModels.Models.Admin.Delivery;
using Application.DTOModels.Response.Admin;
using AutoMapper;
using WebAPIKurs;

namespace Application.MappingProfile.Admin
{
    public class MappingDelivery : Profile
    {
        public MappingDelivery()
        {
            CreateMap<Delivery, DeliveryEditDto>();
            CreateMap<DeliveryEditDto, Delivery>();

            CreateMap<Delivery, DeliveryCreateDto>();
            CreateMap<DeliveryCreateDto, Delivery>();

            CreateMap<Delivery, DeliveryResponseDto>();
        }
    }
}
