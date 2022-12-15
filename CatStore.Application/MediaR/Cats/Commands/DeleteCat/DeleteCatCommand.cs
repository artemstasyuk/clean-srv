using MediatR;

namespace CatStore.Application.MediaR.Cats.Commands.DeleteCat;

public class DeleteCatCommand : IRequest
{
    public Guid Id { get; set; }
}