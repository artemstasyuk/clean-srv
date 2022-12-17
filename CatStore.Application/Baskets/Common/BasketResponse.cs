using AutoMapper;
using CatStore.Application.Common.Mapper;
using CatStore.Domain.BasketAggregate;

namespace CatStore.Application.Baskets.Common;

public class BasketResponse : IMapWith<Basket>
{

    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public int ItemsAmount { get; set; }
    
    public decimal TotalPrice { get; set; }

    public IReadOnlyList<BasketItem> Items { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<Basket, BasketResponse>().ReverseMap();
    
}