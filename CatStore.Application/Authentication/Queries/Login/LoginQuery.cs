using CatStore.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Authentication.Queries.Login;

public class LoginQuery : IRequest<ErrorOr<AuthenticationResult>>
{
    public string Email { get; set; }

    public string Password { get; set; }
}