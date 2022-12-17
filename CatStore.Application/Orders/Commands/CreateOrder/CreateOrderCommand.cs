using CatStore.Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<ErrorOr<Order>>
{

    public string Country { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string HouseNumber { get; set; }
    public Guid UserId { get; set; }
    
}
