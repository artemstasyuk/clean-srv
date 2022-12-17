using CatStore.Application.Common.Interfaces.Cache;
using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.BasketAggregate;
using CatStore.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Baskets.Commands.RemoveItem;

public class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand, ErrorOr<Basket>>
{
    private readonly ICacheService _cacheService;
    private readonly IUserRepository _userRepository;

    public RemoveItemCommandHandler(ICacheService cacheService, IUserRepository userRepository)
    {
        _cacheService = cacheService;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<Basket>> Handle(RemoveItemCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByIdAsync(command.UserId) is not { } user)
            return Errors.User.NotFound;

        var basket = await _cacheService.GetRedisCache<Basket>(user.Id.ToString());
        
        if (basket.Items.SingleOrDefault(el => el.Id == command.ItemId) is not { } item)
            return Errors.Basket.ItemNotFound;
        
        basket.RemoveItem(item.Id);
        
        await _cacheService.SetRedisCache(user.Id.ToString(), basket);

        return basket;
        
    }
}