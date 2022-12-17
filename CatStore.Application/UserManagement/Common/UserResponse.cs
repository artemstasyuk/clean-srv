using AutoMapper;
using CatStore.Application.Common.Mapper;
using CatStore.Domain.UserAggregate;

namespace CatStore.Application.UserManagement.Common;

public class UserResponse : IMapWith<User>
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get;  set; }

    public string Email { get;  set; }

    public string Password { get;  set; }

    public void Mapping(Profile profile) => 
        profile.CreateMap<User, UserResponse>()
        .ReverseMap();
}