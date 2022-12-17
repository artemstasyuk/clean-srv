using FluentValidation;

namespace CatStore.Application.Baskets.Commands.DecreaseItemQuantity;

public class DecreaseItemQuantityCommandValidator : AbstractValidator<DecreaseItemQuantityCommand>
{
    public DecreaseItemQuantityCommandValidator()
    {
        RuleFor(c => c.ItemId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}