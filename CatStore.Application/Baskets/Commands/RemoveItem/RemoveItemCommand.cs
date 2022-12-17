using CatStore.Domain.BasketAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Baskets.Commands.RemoveItem;

public class RemoveItemCommand : IRequest<ErrorOr<Basket>>
{
    public Guid UserId { get; set; }
    public Guid ItemId { get; set; }
}