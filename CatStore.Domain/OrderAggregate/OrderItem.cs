namespace CatStore.Domain.OrderAggregate;

public class OrderItem
{
    public Guid Id { get; private set; }
    
    public Guid OrderId { get; private set; }
    
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    
    public Guid CatId { get; private set; }

    private OrderItem( Guid id, Guid orderId, decimal price, Guid catId, int quantity)
    {
        Id = id;
        OrderId = orderId;
        Price = price;
        CatId = catId;
        Quantity = quantity;
    }

    public static OrderItem Create(Guid orderId,decimal price, Guid catId, int quantity) =>
        new(Guid.NewGuid(), orderId, price,  catId, quantity);
}