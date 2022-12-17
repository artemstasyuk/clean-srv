using AutoMapper;
using CatStore.Application.Cats.Commands.UpdateCat;
using CatStore.Application.Common.Mapper;

namespace CatStore.Application.Common.Dtos.Cat;

public class UpdateCatDto : IMapWith<UpdateCatCommand>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<UpdateCatDto, UpdateCatCommand>();
}