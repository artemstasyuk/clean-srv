using AutoMapper;
using CatStore.Application.Common.Mapper;
using CatStore.Domain.CatAggregate;
using CatStore.Domain.CatAggregate.Enums;

namespace CatStore.Application.Cats.Common;

public class CatResponse : IMapWith<Cat>
{
    public string Name { get; set; }
    
    public Sex Sex { get; set; }

    public decimal Price { get; set; }
    
    public string Description { get; set; }
    
    public string ImageUrl { get; set; }
    
    public void Mapping(Profile profile) =>
        profile.CreateMap<Cat, CatResponse>().ReverseMap();
}