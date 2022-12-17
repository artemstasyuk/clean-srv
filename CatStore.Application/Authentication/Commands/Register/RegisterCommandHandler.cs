using CatStore.Application.Authentication.Common;
using CatStore.Application.Common.Interfaces.Auth;
using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.Common.Errors;
using CatStore.Domain.UserAggregate;
using CatStore.Domain.UserAggregate.Enums;
using CatStore.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    
    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByEmailAsync(command.Email) is not null)
            return Errors.User.DuplicateEmail;

        //Create user and add to db
        var user = User.Create(
            command.FirstName, 
            command.LastName,
            command.Email,
            BCrypt.Net.BCrypt.HashPassword(command.Password), 
            Balance.Create(command.Currency, 0), 
            Role.Customer);
        
        await _userRepository.CreateAsync(user);

        //Jwt token generate
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(){User = user, Token = token};
    }
}