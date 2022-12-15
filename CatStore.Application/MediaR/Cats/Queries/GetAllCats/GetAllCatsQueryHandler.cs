using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Application.Dtos.Cat;
using MediatR;

namespace CatStore.Application.MediaR.Cats.Queries.GetAllCats;


public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, CatListDto>
{
    private readonly ICatRepository _catRepository;

    public GetAllCatsQueryHandler(ICatRepository catRepository)
    {
        _catRepository = catRepository;
    }

    public async Task<CatListDto> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
    {
        var dto = new CatListDto();
        dto.Cats = await _catRepository.GetListAsync();
        
        return dto;
    }
}