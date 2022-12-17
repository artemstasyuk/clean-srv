using CatStore.Domain.BasketAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Baskets.Queries.GetBasket;

public class GetBasketQuery : IRequest<ErrorOr<Basket>>
{
    public Guid UserId { get; set; }
}