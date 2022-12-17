using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.CatAggregate;
using CatStore.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Cats.Commands.DeleteCat;


public class DeleteCatCommandHandler : IRequestHandler<DeleteCatCommand, ErrorOr<Unit>>
{
    private readonly ICatRepository _catRepository;

    public DeleteCatCommandHandler(ICatRepository catRepository)
    {
        _catRepository = catRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteCatCommand request, CancellationToken cancellationToken)
    {
        if (await _catRepository.GetByIdAsync(request.Id) is not { } cat)
            return Errors.Cat.NotFound;
        await _catRepository.DeleteAsync(cat);
        return Unit.Value;
    }
}