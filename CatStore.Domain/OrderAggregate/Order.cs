namespace CatStore.Domain.OrderAggregate;

public class Order
{
    public readonly List<OrderItem> items = new();
    
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public Address  Address { get; set; }
    
    public DateTime Created { get; set; }

    public bool IsShipped { get; set; }

    public decimal TotalPrice { get; set; }

    public IReadOnlyList<OrderItem> OrderItems => items.AsReadOnly();
    
    private Order(Guid id, Address address, Guid userId, DateTime created)
    {
        Address = address;
        UserId = userId;
        Created = created;
    }

    public static Order Create(Guid id, Guid userId, Address address) =>
        new Order(Guid.NewGuid(), address, userId, DateTime.UtcNow);
    
}