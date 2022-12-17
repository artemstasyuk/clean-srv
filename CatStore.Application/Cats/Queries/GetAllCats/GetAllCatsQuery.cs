using CatStore.Domain.CatAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Cats.Queries.GetAllCats;

public class GetAllCatsQuery : IRequest<ErrorOr<List<Cat>>>
{
    
}
