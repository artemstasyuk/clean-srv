using CatStore.Application.MediaR.Authentication.Common;
using CatStore.Domain.UserAggregate.Enums;
using ErrorOr;
using MediatR;

namespace CatStore.Application.MediaR.Authentication.Commands.Register;

public class RegisterCommand : IRequest<ErrorOr<AuthenticationResult>>
{
    public string FirstName { get; set; }
    
    public Currency Currency { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}