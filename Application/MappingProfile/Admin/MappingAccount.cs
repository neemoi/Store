using AutoMapper;
using WebAPIKurs;
using Application.DTOModels.Models.Admin.Authorization;
using Application.DTOModels.Response.Admin.Authorization;

namespace Application.MappingProfile.Admin
{
    public class MappingAccount : Profile
    {
        public MappingAccount()
        {
            CreateMap<RegisterDto, CustomUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name));
            CreateMap<CustomUser, LoginResponseDto>();
            CreateMap<CustomUser, RegisterResponseDto>();
            CreateMap<CustomUser, LogoutResponseDto>();
        }
    }
}