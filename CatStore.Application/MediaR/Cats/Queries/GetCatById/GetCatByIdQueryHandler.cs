using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace CatStore.Application.MediaR.Cats.Queries.GetCatById;


public class GetCatByIdHandle : IRequestHandler<GetCatByIdQuery, ErrorOr<Domain.CatAggregate.Cat>>
{
    private readonly ICatRepository _catRepository;
    
    public GetCatByIdHandle(ICatRepository catRepository)
    {
        _catRepository = catRepository;
    }

    public async Task<ErrorOr<Domain.CatAggregate.Cat>> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
    {
        if (await _catRepository.GetByIdAsync(request.Id) is not { } cat)
            return Errors.Cat.NotFound;
        return cat;
    }
}