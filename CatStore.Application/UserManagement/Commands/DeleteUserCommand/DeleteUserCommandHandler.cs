using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace CatStore.Application.UserManagement.Commands.DeleteUserCommand;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByIdAsync(command.UserId) is not { } user)
            return Errors.User.NotFound;
        await _userRepository.DeleteAsync(user);
        return Unit.Value;
    }

}