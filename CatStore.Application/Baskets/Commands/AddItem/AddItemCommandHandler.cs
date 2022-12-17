using CatStore.Application.Common.Interfaces.Cache;
using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.BasketAggregate;
using CatStore.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Baskets.Commands.AddItem;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand,ErrorOr<Basket>>
{
    private readonly ICacheService _cacheService;
    private readonly IUserRepository _userRepository;
    private readonly ICatRepository _catRepository;
    
    public AddItemCommandHandler(ICacheService cacheService, IUserRepository userRepository, ICatRepository catRepository)
    {
        _cacheService = cacheService;
        _userRepository = userRepository;
        _catRepository = catRepository;
    }

    public async Task<ErrorOr<Basket>> Handle(AddItemCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByIdAsync(command.UserId) is not {} user)
            return Errors.User.NotFound;

        var basket = await _cacheService.GetRedisCache<Basket>(user.Id.ToString())
            ?? Basket.Create(user.Id);

        if ( await _catRepository.GetByIdAsync(command.CatId) is not { } )
            return Errors.Cat.NotFound;
        
        basket.AddItem(command.CatId, command.UnitPrice, command.Quantity);

        await _cacheService.SetRedisCache(user.Id.ToString(), basket);

        return basket;
    }
}