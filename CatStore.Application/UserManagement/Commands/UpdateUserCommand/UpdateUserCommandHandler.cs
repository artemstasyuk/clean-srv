using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.Common.Errors;
using CatStore.Domain.UserAggregate;
using MediatR;
using ErrorOr;

namespace CatStore.Application.UserManagement.Commands.UpdateUserCommand;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<User>>
{
    private readonly IUserRepository _userRepository;
    
    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<User>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByIdAsync(command.UserId) is not { } user)
            return Errors.User.NotFound;
        
        if (BCrypt.Net.BCrypt.Verify(command.Password, user.Password))
            return Errors.User.DuplicatePassword;

        if (user.Email == command.Email)
            return Errors.User.DuplicateEmail;

        var updatedUser = user.Update(
            command.FirstName, 
            command.LastName, 
            command.Email, 
            command.Password);

        await _userRepository.UpdateAsync(updatedUser);
        return updatedUser;

    }
}