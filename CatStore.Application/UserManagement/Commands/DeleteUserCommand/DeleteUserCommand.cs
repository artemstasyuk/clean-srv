using MediatR;
using ErrorOr;

namespace CatStore.Application.UserManagement.Commands.DeleteUserCommand;

public class DeleteUserCommand : IRequest<ErrorOr<Unit>>
{
    public Guid UserId { get; set; }
}