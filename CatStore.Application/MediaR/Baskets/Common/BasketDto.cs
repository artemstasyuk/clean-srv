using AutoMapper;
using CatStore.Application.Mapper;
using CatStore.Domain.BasketAggregate;

namespace CatStore.Application.MediaR.Baskets.Common;

public class BasketDto : IMapWith<Basket>
{

    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public int ItemsAmount { get; set; }
    
    public decimal TotalPrice { get; set; }

    public IReadOnlyList<BasketItem> Items { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<Basket, BasketDto>().ReverseMap();


}