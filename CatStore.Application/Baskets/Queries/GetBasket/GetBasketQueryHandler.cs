using CatStore.Application.Common.Interfaces.Cache;
using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.BasketAggregate;
using CatStore.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Baskets.Queries.GetBasket;

public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, ErrorOr<Basket>>
{
    private readonly ICacheService _cacheService;
    private readonly IUserRepository _userRepository;

    public GetBasketQueryHandler(ICacheService cacheService, IUserRepository userRepository)
    {
        _cacheService = cacheService;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Basket>> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByIdAsync(query.UserId) is not { } user)
            return Errors.User.NotFound;

        var basket = await _cacheService.GetRedisCache<Basket>(user.Id.ToString());

        if (basket is not null) return basket;

        var voidBasket = Basket.Create(user.Id);
        await _cacheService.SetRedisCache(user.Id.ToString(), voidBasket);

        return voidBasket;
    }
}