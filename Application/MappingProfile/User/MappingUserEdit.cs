using Application.DTOModels.Models.User;
using Application.DTOModels.Response.User;
using AutoMapper;
using WebAPIKurs;

namespace Application.MappingProfile.User
{
    public class MappingUserEdit : Profile
    {
        public MappingUserEdit()
        {
            CreateMap<EditProfileDto, CustomUser>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CustomUser, EditProfileResposneDto>();
        }
    }
}
