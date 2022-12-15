using AutoMapper;
using CatStore.Application.Dtos.Auth;
using CatStore.Application.Mapper;
using CatStore.Domain.UserAggregate;

namespace CatStore.Application.MediaR.Authentication.Common;

public class AuthenticationResult : IMapWith<AuthenticationResponse>
{

    public User User { get; set; }
    
    public string Token { get; set; }
    
    public void Mapping(Profile profile) =>
        profile.CreateMap<AuthenticationResult, AuthenticationResponse>()
    .ForMember(d => d.Id, opt => 
        opt.MapFrom(s => s.User.Id))
    .ForMember(d => d.FirstName, opt => 
        opt.MapFrom(s => s.User.FirstName))
    .ForMember(d => d.LastName, opt => 
        opt.MapFrom(s => s.User.LastName))
    .ForMember(d => d.Email, opt => 
        opt.MapFrom(s => s.User.Email));
}
   