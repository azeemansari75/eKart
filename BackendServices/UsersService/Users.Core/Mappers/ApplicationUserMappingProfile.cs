using AutoMapper;
using Users.Core.DTOs;
using Users.Core.Entities;

namespace Users.Core.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        //ApplicationUser -> Authentication
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
            .ForMember(dest => dest.Success, opt => opt.Ignore())
            .ForMember(dest => dest.Token, opt => opt.Ignore())
            .ReverseMap();
    }
}
