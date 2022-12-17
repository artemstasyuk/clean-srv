using CatStore.Domain.BasketAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.MediaR.Baskets.Commands.ClearItems;

public class ClearItemsCommand : IRequest<ErrorOr<Basket>>
{
    public Guid UserId { get; set; }
}