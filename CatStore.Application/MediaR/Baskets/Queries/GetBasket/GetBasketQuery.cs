using CatStore.Domain.BasketAggregate;
using MediatR;
using ErrorOr;

namespace CatStore.Application.MediaR.Baskets.Queries.GetBasket;

public class GetBasketQuery : IRequest<ErrorOr<Basket>>
{
    public Guid UserId { get; set; }
}