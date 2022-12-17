using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.CatAggregate;
using CatStore.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Cats.Queries.GetCatById;


public class GetCatByIdHandle : IRequestHandler<GetCatByIdQuery, ErrorOr<Cat>>
{
    private readonly ICatRepository _catRepository;
    
    public GetCatByIdHandle(ICatRepository catRepository)
    {
        _catRepository = catRepository;
    }

    public async Task<ErrorOr<Cat>> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
    {
        if (await _catRepository.GetByIdAsync(request.Id) is not { } cat)
            return Errors.Cat.NotFound;
        return cat;
    }
}