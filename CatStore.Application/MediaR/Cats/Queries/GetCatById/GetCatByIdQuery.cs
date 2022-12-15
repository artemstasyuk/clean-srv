using ErrorOr;
using MediatR;

namespace CatStore.Application.MediaR.Cats.Queries.GetCatById;

public class GetCatByIdQuery : IRequest<ErrorOr<Domain.CatAggregate.Cat>>
{
    public Guid Id { get; set; }
}