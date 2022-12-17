using CatStore.Application.MediaR.Baskets.Commands.RemoveItem;
using FluentValidation;

namespace CatStore.Application.MediaR.Baskets.Commands.DecreaseItemQuantity;

public class DecreaseItemQuantityCommandValidator : AbstractValidator<DecreaseItemQuantityCommand>
{
    public DecreaseItemQuantityCommandValidator()
    {
        RuleFor(c => c.CatId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}