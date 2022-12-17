using AutoMapper;
using CatStore.Application.Common.Mapper;
using CatStore.Domain.OrderAggregate;
using CatStore.Domain.OrderAggregate.ValuesObject;

namespace CatStore.Application.Orders.Common;

public class OrderResponse : IMapWith<Order>
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public Address  Address { get; set; }
    
    public DateTime Created { get; set; }

    public bool IsShipped { get; set; }

    public decimal TotalPrice { get; set; }

    public IReadOnlyList<OrderItem> OrderItems { get; set; }
    
    public void Mapping(Profile profile) =>
        profile.CreateMap<Order, OrderResponse>().ReverseMap();
}