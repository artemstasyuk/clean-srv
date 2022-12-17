using FluentValidation;

namespace CatStore.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(c => c.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required");
        RuleFor(c => c.Password).MinimumLength(6).WithMessage("Password minimum lenght is 6").NotEmpty();
    }
}