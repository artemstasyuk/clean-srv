using CatStore.Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Orders.Queries.GetAllUserOrders;

public class GetAllUserOrdersQuery : IRequest<ErrorOr<List<Order>>>
{
    public Guid UserId { get; set; }
}