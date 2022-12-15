using CatStore.Domain.CatAggregate.Enums;
using MediatR;

namespace CatStore.Application.MediaR.Cats.Commands.CreateCat;

public class CreateCatCommand : IRequest
{
    public string Name { get; set; }
    
    public Sex Sex { get; set; }

    public decimal Price { get; set; }
    
    public string Description { get; set; }
    
     public string ImageUrl { get; set; }
}