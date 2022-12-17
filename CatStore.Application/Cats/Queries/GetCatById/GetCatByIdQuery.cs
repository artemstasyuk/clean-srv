using CatStore.Domain.CatAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Cats.Queries.GetCatById;

public class GetCatByIdQuery : IRequest<ErrorOr<Cat>>
{
    public Guid Id { get; set; }
}