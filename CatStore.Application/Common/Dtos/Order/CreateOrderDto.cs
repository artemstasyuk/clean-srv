using AutoMapper;
using CatStore.Application.Common.Mapper;
using CatStore.Application.Orders.Commands.CreateOrder;

namespace CatStore.Application.Common.Dtos.Order;

public class CreateOrderDto : IMapWith<CreateOrderCommand>
{
    public string Country { get; set; }
    
    public string City { get; set; }
    
    public string Street { get; set; }
    
    public string HouseNumber { get; set; }
    
    public Guid UserId { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<CreateOrderDto, CreateOrderCommand>();
}
