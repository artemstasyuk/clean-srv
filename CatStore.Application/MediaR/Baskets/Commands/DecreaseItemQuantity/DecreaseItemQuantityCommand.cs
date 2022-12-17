using CatStore.Domain.BasketAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.MediaR.Baskets.Commands.DecreaseItemQuantity;

public class DecreaseItemQuantityCommand : IRequest<ErrorOr<Basket>>
{
    public Guid UserId { get; set; }
    
    public Guid CatId { get; set; }
    
}