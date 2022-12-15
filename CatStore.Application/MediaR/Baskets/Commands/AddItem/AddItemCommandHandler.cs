using AutoMapper;
using CatStore.Application.Common.Interfaces.Cache;
using CatStore.Application.Common.Interfaces.Persistence;
using ErrorOr;
using CatStore.Domain.BasketAggregate;
using CatStore.Domain.Common.Errors;
using MediatR;

namespace CatStore.Application.MediaR.Baskets.Commands.AddItem;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand,ErrorOr<Basket>>
{
    private readonly ICacheService _cacheService;
    private readonly IUserRepository _userRepository;
    
    public AddItemCommandHandler(ICacheService cacheService, IUserRepository userRepository)
    {
        _cacheService = cacheService;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Basket>> Handle(AddItemCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByIdAsync(command.UserId) is not { } user)
            return Errors.User.NotFound;
        
        var basket = await _cacheService.GetRedisCache<Basket>("basket")
                     ?? Basket.Create(command.UserId);
        basket.AddItem(command.CatId, command.UnitPrice, command.Quantity);

        await _cacheService.SetRedisCache("basket", basket);

        return basket;
    }
}