using AutoMapper;
using CatStore.Application.Mapper;
using CatStore.Application.MediaR.Authentication.Commands.Register;

namespace CatStore.Application.Dtos.Auth;

public class RegisterDto : IMapWith<RegisterCommand>
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public void Mapping(Profile profile) =>
        profile.CreateMap<RegisterDto, RegisterCommand>();
}