using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.CatAggregate;
using CatStore.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Cats.Commands.UpdateCat;


public class UpdateCatCommandHandler : IRequestHandler<UpdateCatCommand, ErrorOr<Cat>>
{
    private readonly ICatRepository _catRepository;

    public UpdateCatCommandHandler(ICatRepository catRepository)
    {
        _catRepository = catRepository;
    }

    public async Task<ErrorOr<Cat>> Handle(UpdateCatCommand request, CancellationToken cancellationToken)
    {
        if (await _catRepository.GetByIdAsync(request.Id) is not { } cat)
            return Errors.Cat.NotFound;

        var updatedCat = cat.Update(request.Name, request.Sex, request.ImageUrl, request.Price, request.Description);

        await _catRepository.UpdateAsync(updatedCat);
        return updatedCat;
    }

}