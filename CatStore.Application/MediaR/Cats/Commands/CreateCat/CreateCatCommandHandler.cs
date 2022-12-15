using CatStore.Application.Common.Interfaces.Persistence;
using MediatR;

namespace CatStore.Application.MediaR.Cats.Commands.CreateCat;


public class CreateCatCommandHandler : IRequestHandler<CreateCatCommand, Unit>
{
    private readonly ICatRepository _catRepository;

    public CreateCatCommandHandler(ICatRepository catRepository)
    {
        _catRepository = catRepository;
    }
    
    public async Task<Unit> Handle(CreateCatCommand command, CancellationToken cancellationToken)
    {
        var cat = Domain.CatAggregate.Cat.Create(
            command.Name,
            command.Sex,
            command.ImageUrl, 
            command.Price, 
            command.Description);

        await _catRepository.CreateAsync(cat);
        return Unit.Value;
    }
}