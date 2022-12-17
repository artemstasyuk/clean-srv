using AutoMapper;
using CatStore.Application.Common.Mapper;
using CatStore.Application.UserManagement.Commands.UpdateUserCommand;

namespace CatStore.Application.Common.Dtos.Users;

public class UpdateUserDto : IMapWith<UpdateUserCommand>
{
    public Guid UserId { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get;  set; }

    public string Email { get;  set; }

    public string Password { get;  set; }
    
    public void Mapping(Profile profile) =>
        profile.CreateMap<UpdateUserDto, UpdateUserCommand>();
}