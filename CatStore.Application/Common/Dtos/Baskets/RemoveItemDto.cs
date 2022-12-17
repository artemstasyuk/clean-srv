using AutoMapper;
using CatStore.Application.Baskets.Commands.RemoveItem;
using CatStore.Application.Common.Mapper;

namespace CatStore.Application.Common.Dtos.Baskets;

public class RemoveItemDto : IMapWith<RemoveItemCommand>
{
    public Guid UserId { get; set; }
    
    public Guid ItemId { get; set; }
    public void Mapping(Profile profile) =>
        profile.CreateMap<RemoveItemDto, RemoveItemCommand>();
}