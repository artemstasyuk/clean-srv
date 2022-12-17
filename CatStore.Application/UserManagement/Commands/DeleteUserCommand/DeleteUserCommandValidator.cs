using FluentValidation;

namespace CatStore.Application.UserManagement.Commands.DeleteUserCommand;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(el => el.UserId).NotEmpty();
    }
}