using CatStore.Domain.BasketAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.MediaR.Baskets.Commands.RemoveItem;

public class RemoveItemCommand : IRequest<ErrorOr<Basket>>
{
    public Guid UserId { get; set; }
    public Guid CatId { get; set; }
}