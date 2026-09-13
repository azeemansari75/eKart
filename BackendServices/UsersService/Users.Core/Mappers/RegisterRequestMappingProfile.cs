using AutoMapper;
using Users.Core.DTOs;
using Users.Core.Entities;

namespace Users.Core.Mappers;

public class RegisterRequestMappingProfile : Profile
{
    public RegisterRequestMappingProfile()
    {
        //RegisterRequest -> ApplicationUser
        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src =>src.Gender.ToString()))
            .ReverseMap();
    }
}
