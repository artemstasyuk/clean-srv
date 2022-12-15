using CatStore.Application.Common.Interfaces.Persistence;
using MediatR;

namespace CatStore.Application.MediaR.Cats.Commands.DeleteCat;


public class DeleteCatCommandHandler : IRequestHandler<DeleteCatCommand, Unit>
{
    private readonly ICatRepository _catRepository;

    public DeleteCatCommandHandler(ICatRepository catRepository)
    {
        _catRepository = catRepository;
    }

    public async Task<Unit> Handle(DeleteCatCommand request, CancellationToken cancellationToken)
    {
        var cat = await _catRepository.GetByIdAsync(request.Id);
        await _catRepository.DeleteAsync(cat);
        return Unit.Value;
    }
}