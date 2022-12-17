using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.CatAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Cats.Queries.GetAllCats;


public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, ErrorOr<List<Cat>>>
{
    private readonly ICatRepository _catRepository;

    public GetAllCatsQueryHandler(ICatRepository catRepository)
    {
        _catRepository = catRepository;
    }

    public async Task<ErrorOr<List<Cat>>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
    {
        var cats= await _catRepository.GetListAsync();
        
        return cats;
    }
}