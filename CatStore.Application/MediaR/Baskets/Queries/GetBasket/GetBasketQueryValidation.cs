using CatStore.Domain.BasketAggregate;
using FluentValidation;

namespace CatStore.Application.MediaR.Baskets.Queries.GetBasket;

public class GetBasketQueryValidation : AbstractValidator<Basket>
{
    public GetBasketQueryValidation()
    {
        RuleFor(q => q.UserId).NotEmpty();
    }
}