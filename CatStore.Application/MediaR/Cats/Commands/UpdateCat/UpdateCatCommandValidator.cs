using FluentValidation;

namespace CatStore.Application.MediaR.Cats.Commands.UpdateCat;

public class UpdateCatCommandValidator : AbstractValidator<UpdateCatCommand>
{
    public UpdateCatCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.ImageUrl).NotEmpty();
    }
}