using FluentValidation;

namespace CatStore.Application.MediaR.Baskets.Commands.ClearItems;

public class ClearItemsCommandValidator : AbstractValidator<ClearItemsCommand>
{
    public ClearItemsCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
    }
}