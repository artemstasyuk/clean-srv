using CatStore.Domain.BasketAggregate;
using FluentValidation;

namespace CatStore.Application.Baskets.Queries.GetBasket;

public class GetBasketQueryValidation : AbstractValidator<Basket>
{
    public GetBasketQueryValidation()
    {
        RuleFor(q => q.UserId).NotEmpty();
    }
}