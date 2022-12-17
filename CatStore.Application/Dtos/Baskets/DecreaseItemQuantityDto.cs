using AutoMapper;
using CatStore.Application.Mapper;
using CatStore.Application.MediaR.Baskets.Commands.DecreaseItemQuantity;
using CatStore.Application.MediaR.Baskets.Commands.RemoveItem;

namespace CatStore.Application.Dtos.Baskets;

public class DecreaseItemQuantityDto : IMapWith<DecreaseItemQuantityCommand>
{
    public Guid UserId { get; set; }
    
    public Guid CatId { get; set; }
    
    public void Mapping(Profile profile) =>
        profile.CreateMap<DecreaseItemQuantityDto, DecreaseItemQuantityCommand>();
}