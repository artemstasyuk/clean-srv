using AutoMapper;
using CatStore.Application.Mapper;
using CatStore.Application.MediaR.Baskets.Commands.AddItem;

namespace CatStore.Application.Dtos.Baskets;

public class AddItemDto : IMapWith<AddItemCommand>
{
    public Guid UserId { get; set; }
    public Guid CatId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    
    public void Mapping(Profile profile) =>
        profile.CreateMap<AddItemDto, AddItemCommand>();
}
