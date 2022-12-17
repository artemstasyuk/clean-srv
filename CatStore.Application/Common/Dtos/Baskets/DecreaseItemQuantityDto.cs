using AutoMapper;
using CatStore.Application.Baskets.Commands.DecreaseItemQuantity;
using CatStore.Application.Common.Mapper;

namespace CatStore.Application.Common.Dtos.Baskets;

public class DecreaseItemQuantityDto : IMapWith<DecreaseItemQuantityCommand>
{
    public Guid UserId { get; set; }
    
    public Guid ItemId { get; set; }
    
    public void Mapping(Profile profile) =>
        profile.CreateMap<DecreaseItemQuantityDto, DecreaseItemQuantityCommand>();
}