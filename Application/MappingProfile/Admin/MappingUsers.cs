using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using AutoMapper;
using WebAPIKurs;

namespace Application.MappingProfile.Admin
{
    public class MappingUsers : Profile
    {
        public MappingUsers()
        {
            CreateMap<UserDto, CustomUser>();

            CreateMap<CustomUser, UserResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State));
        }
    }
}