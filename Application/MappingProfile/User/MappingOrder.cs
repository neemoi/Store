using Application.DTOModels.Models.Admin;
using Application.DTOModels.Models.User.Order;
using Application.DTOModels.Response.User;
using AutoMapper;
using WebAPIKurs;

public class MappingOrder : Profile
{
    public MappingOrder()
    {
        CreateMap<Order, OrderCreateDto>();
        CreateMap<OrderCreateDto, Order>();

        CreateMap<Order, OrderEditDto>();
        CreateMap<OrderEditDto, Order>();

        CreateMap<CustomUser, OrderEditDto>();
        CreateMap<OrderEditDto, CustomUser>();

        CreateMap<Order, UserOrderEditDto>();
        CreateMap<UserOrderEditDto, Order>();

        CreateMap<Orderitem, OrderResponseDto>();

        CreateMap<Order, OrderResponseDto>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
            .ForMember(dest => dest.TypePayment, opt => opt.MapFrom(src => src.Payments.Type))
            .ForMember(dest => dest.AmountPayment, opt => opt.MapFrom(src => src.Payments.Amount))
            .ForMember(dest => dest.TypeDelivery, opt => opt.MapFrom(src => src.Deliveries.Type))
            .ForMember(dest => dest.AmountDelivery, opt => opt.MapFrom(src => src.Deliveries.Price))
            .ForMember(dest => dest.ListProductPrices, opt => opt.MapFrom(src => src.Orderitems.Select(oi => oi.Product.Price).ToList()))
            .ForMember(dest => dest.ListProductName, opt => opt.MapFrom(src => src.Orderitems.Select(oi => oi.Product.Name).ToList()))
            .ForMember(dest => dest.ListProductMemory, opt => opt.MapFrom(src => src.Orderitems.Select(oi => oi.Product.Memory).ToList()))
            .ForMember(dest => dest.ListProductColor, opt => opt.MapFrom(src => src.Orderitems.Select(oi => oi.Product.Color).ToList()));

        CreateMap<Order, UserOrderResponseDto>()
           .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
           .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
           .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
           .ForMember(dest => dest.TypePayment, opt => opt.MapFrom(src => src.Payments.Type))
           .ForMember(dest => dest.AmountPayment, opt => opt.MapFrom(src => src.Payments.Amount))
           .ForMember(dest => dest.TypeDelivery, opt => opt.MapFrom(src => src.Deliveries.Type))
           .ForMember(dest => dest.AmountDelivery, opt => opt.MapFrom(src => src.Deliveries.Price))
           .ForMember(dest => dest.ListProductPrices, opt => opt.MapFrom(src => src.Orderitems.Select(oi => oi.Product.Price).ToList()))
           .ForMember(dest => dest.ListProductName, opt => opt.MapFrom(src => src.Orderitems.Select(oi => oi.Product.Name).ToList()))
           .ForMember(dest => dest.ListProductMemory, opt => opt.MapFrom(src => src.Orderitems.Select(oi => oi.Product.Memory).ToList()))
           .ForMember(dest => dest.ListProductColor, opt => opt.MapFrom(src => src.Orderitems.Select(oi => oi.Product.Color).ToList()));
    }
}
