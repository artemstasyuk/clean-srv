using FluentValidation;

namespace CatStore.Application.MediaR.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required");
        RuleFor(c => c.Password).MinimumLength(6).WithMessage("Password minimum lenght is 6").NotEmpty();
    }
}