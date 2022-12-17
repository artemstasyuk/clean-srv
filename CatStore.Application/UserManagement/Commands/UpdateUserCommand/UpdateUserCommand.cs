using CatStore.Domain.UserAggregate;
using MediatR;
using ErrorOr;

namespace CatStore.Application.UserManagement.Commands.UpdateUserCommand;

public class UpdateUserCommand : IRequest<ErrorOr<User>>
{
    public Guid UserId { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get;  set; }

    public string Email { get;  set; }

    public string Password { get;  set; }
    
}