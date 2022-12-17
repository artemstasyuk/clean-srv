using CatStore.Domain.CatAggregate;
using CatStore.Domain.CatAggregate.Enums;
using ErrorOr;
using MediatR;

namespace CatStore.Application.Cats.Commands.CreateCat;

public class CreateCatCommand : IRequest<ErrorOr<Cat>>
{
    public string Name { get; set; }
    
    public Sex Sex { get; set; }

    public decimal Price { get; set; }
    
    public string Description { get; set; }
    
     public string ImageUrl { get; set; }
}