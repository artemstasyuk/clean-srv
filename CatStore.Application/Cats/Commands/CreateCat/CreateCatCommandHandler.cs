using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.CatAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Cats.Commands.CreateCat;


public class CreateCatCommandHandler : IRequestHandler<CreateCatCommand, ErrorOr<Cat>>
{
    private readonly ICatRepository _catRepository;

    public CreateCatCommandHandler(ICatRepository catRepository)
    {
        _catRepository = catRepository;
    }
    
    public async Task<ErrorOr<Cat>> Handle(CreateCatCommand command, CancellationToken cancellationToken)
    {
        var cat = Cat.Create(
            command.Name,
            command.Sex,
            command.ImageUrl, 
            command.Price, 
            command.Description);

        await _catRepository.CreateAsync(cat);
        return cat;
    }
}