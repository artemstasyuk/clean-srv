using AutoMapper;
using CatStore.Application.Mapper;
using CatStore.Application.MediaR.Cats.Commands.CreateCat;

namespace CatStore.Application.Dtos.Cat;

public class CreateCatDto : IMapWith<CreateCatCommand>
{
    
    public string Name { get; set; }

    public decimal Price { get; set; }
    
    public string Description { get; set; }
    
    public string ImageUrl { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<CreateCatDto, CreateCatCommand>();

}