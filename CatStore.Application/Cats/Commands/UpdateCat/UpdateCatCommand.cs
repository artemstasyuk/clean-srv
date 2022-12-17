using CatStore.Domain.CatAggregate.Enums;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Cats.Commands.UpdateCat;

public class UpdateCatCommand : IRequest<ErrorOr<Domain.CatAggregate.Cat>>
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public Sex Sex { get; set; }
    
    public string Description { get; set; }

    public decimal Price { get; set; }
    
    public string ImageUrl { get; set; }
    
}