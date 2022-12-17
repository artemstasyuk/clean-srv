using CatStore.Application.Common.Interfaces.Cache;
using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Application.MediaR.Baskets.Commands.RemoveItem;
using CatStore.Domain.BasketAggregate;
using CatStore.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace CatStore.Application.MediaR.Baskets.Commands.DecreaseItemQuantity;

public class DecreaseItemQuantityCommandHandler : IRequestHandler<DecreaseItemQuantityCommand, ErrorOr<Basket>>
{
    private readonly ICacheService _cacheService;
    private readonly IUserRepository _userRepository;

    public DecreaseItemQuantityCommandHandler(ICacheService cacheService, IUserRepository userRepository)
    {
        _cacheService = cacheService;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Basket>> Handle(DecreaseItemQuantityCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByIdAsync(command.UserId) is not { } user)
            return Errors.User.NotFound;

        var basket = await _cacheService.GetRedisCache<Basket>(user.Id.ToString());
        
        basket.DecreaseItemQuantity(command.CatId);
        
        await _cacheService.SetRedisCache(user.Id.ToString(), basket);

        return basket;
        
    }
}