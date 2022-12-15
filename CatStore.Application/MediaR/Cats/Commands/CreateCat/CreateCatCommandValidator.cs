using FluentValidation;

namespace CatStore.Application.MediaR.Cats.Commands.CreateCat;

public class CreateCatCommandValidator : AbstractValidator<CreateCatCommand>
{
    public CreateCatCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.ImageUrl).NotEmpty();
    }
}