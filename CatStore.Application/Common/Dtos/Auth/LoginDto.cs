using AutoMapper;
using CatStore.Application.Authentication.Queries.Login;
using CatStore.Application.Common.Mapper;

namespace CatStore.Application.Common.Dtos.Auth;

public class LoginDto : IMapWith<LoginQuery>
{
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public void Mapping(Profile profile) =>
        profile.CreateMap<LoginDto, LoginQuery>();
}