using ErrorOr;
using MediatR;

namespace CatStore.Application.Cats.Commands.DeleteCat;

public class DeleteCatCommand : IRequest<ErrorOr<Unit>>
{
    public Guid Id { get; set; }
}