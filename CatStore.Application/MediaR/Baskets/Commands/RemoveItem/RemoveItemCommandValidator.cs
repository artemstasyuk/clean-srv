using FluentValidation;

namespace CatStore.Application.MediaR.Baskets.Commands.RemoveItem;

public class RemoveItemCommandValidator : AbstractValidator<RemoveItemCommand>
{
    public RemoveItemCommandValidator()
    {
        RuleFor(c => c.CatId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}