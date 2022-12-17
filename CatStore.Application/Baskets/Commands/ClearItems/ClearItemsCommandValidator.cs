using FluentValidation;

namespace CatStore.Application.Baskets.Commands.ClearItems;

public class ClearItemsCommandValidator : AbstractValidator<ClearItemsCommand>
{
    public ClearItemsCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
    }
}