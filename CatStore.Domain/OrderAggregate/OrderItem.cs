namespace CatStore.Domain.OrderAggregate;

public class OrderItem
{
    
    public Guid Id { get; private set; }
    public decimal Price { get; private set; }
    
    public Guid CatId { get; private set; }

    private OrderItem( Guid id, decimal price, Guid catId)
    {
        Id = id;
        Price = price;
        CatId = catId;
    }

    public static OrderItem Create(Guid id,  decimal price, Guid catId) =>
        new(Guid.NewGuid(), price, catId);
}