using AutoMapper;

namespace CatStore.Application.Mapper;

// base interface for Mappings 
public interface IMapWith<T>
{
    void Mapping(Profile profile) =>
        profile.CreateMap(typeof(T), GetType());
}