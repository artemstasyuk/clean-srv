using FluentValidation;

namespace CatStore.Application.Baskets.Commands.AddItem;

public class AddItemCommandValidator : AbstractValidator<AddItemCommand>
{
    public AddItemCommandValidator()
    {
        RuleFor(c => c.UnitPrice).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
        RuleFor(c => c.CatId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}