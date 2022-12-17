using CatStore.Domain.OrderAggregate.ValuesObject;

namespace CatStore.Domain.OrderAggregate;

public class Order
{
    public readonly List<OrderItem> _items = new();
    
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public Address  Address { get; set; }
    
    public DateTime Created { get; set; }

    public bool IsShipped { get; set; }

    public decimal TotalPrice { get; set; }

    public IReadOnlyList<OrderItem> OrderItems => _items.AsReadOnly();
    
    private Order(Guid id, Address address, Guid userId, DateTime created)
    {
        Id = id;
        Address = address;
        UserId = userId;
        Created = created;
    }
    
    public static Order Create(Address address, Guid userId) =>
        new Order(Guid.NewGuid(), address, userId, DateTime.UtcNow);
    
    public void AddItems(List<OrderItem> items) => _items.AddRange(items);
    
}