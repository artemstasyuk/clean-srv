using CatStore.Application.Common.Interfaces.Cache;
using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.BasketAggregate;
using CatStore.Domain.Common.Errors;
using CatStore.Domain.OrderAggregate;
using CatStore.Domain.OrderAggregate.ValuesObject;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ErrorOr<Order>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICacheService _cacheService;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, ICacheService cacheService, IUserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _cacheService = cacheService;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<Order>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByIdAsync(command.UserId) is not { } user)
            return Errors.User.NotFound;
        
        var basket = await _cacheService.GetRedisCache<Basket>(user.Id.ToString()!);
        
        //Validate
        if (basket is null || basket.Items.Count == 0)
            return Errors.Basket.BasketEmpty;
        
        //Create order
        var order = Order.Create( 
            Address.Create(
                command.Country,
                command.City,
                command.Street,
                command.HouseNumber), 
            command.UserId);
        
        var items = basket.Items.Select(item => 
            OrderItem.Create(order.Id, item.UnitPrice, item.CatId, item.Quantity)).ToList();
        order.AddItems(items);
        
        //Calculate
        var totalPrice = basket.TotalPrice;
        order.TotalPrice = totalPrice;
        if (totalPrice > user.Balance.Amount) return Errors.User.NotEnoughBalance;
        user.Balance.Debit(totalPrice);
        
        order.IsShipped = true;

        //Save
        await _orderRepository.CreateAsync(order);
        await _userRepository.UpdateAsync(user);
        
        await _cacheService.RemoveRedisCache(user.Id.ToString()!);
        return order;
    }
}