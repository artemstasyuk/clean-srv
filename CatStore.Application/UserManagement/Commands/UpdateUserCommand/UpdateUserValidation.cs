using FluentValidation;

namespace CatStore.Application.UserManagement.Commands.UpdateUserCommand;

public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidation()
    {
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required");
        RuleFor(c => c.Password).MinimumLength(6).WithMessage("Password minimum lenght is 6").NotEmpty();
    }
}