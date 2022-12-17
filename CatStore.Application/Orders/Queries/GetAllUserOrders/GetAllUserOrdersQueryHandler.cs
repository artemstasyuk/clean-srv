using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Orders.Queries.GetAllUserOrders;

public class GetAllUserOrdersQueryHandler : IRequestHandler<GetAllUserOrdersQuery, ErrorOr<List<Order>>>
{
private readonly IOrderRepository _orderRepository;

    public GetAllUserOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<ErrorOr<List<Order>>> Handle(GetAllUserOrdersQuery query, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetListByUserIdAsync(query.UserId) ;
    
        return orders ;
    }
    
}