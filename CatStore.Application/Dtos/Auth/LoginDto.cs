using AutoMapper;
using CatStore.Application.Mapper;
using CatStore.Application.MediaR.Authentication.Queries.Login;

namespace CatStore.Application.Dtos.Auth;

public class LoginDto : IMapWith<LoginQuery>
{
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public void Mapping(Profile profile) =>
        profile.CreateMap<LoginDto, LoginQuery>();
}