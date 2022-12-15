using AutoMapper;
using CatStore.Application.Mapper;
using CatStore.Application.MediaR.Cats.Commands.UpdateCat;

namespace CatStore.Application.Dtos.Cat;

public class UpdateCatDto : IMapWith<UpdateCatCommand>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<UpdateCatDto, UpdateCatCommand>();
}