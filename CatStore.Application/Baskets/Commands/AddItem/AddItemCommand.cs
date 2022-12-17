using CatStore.Domain.BasketAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Baskets.Commands.AddItem;

public class AddItemCommand : IRequest<ErrorOr<Basket>>
{
    public Guid UserId { get; set; }
    public Guid CatId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}