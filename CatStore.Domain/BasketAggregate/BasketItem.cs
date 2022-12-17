using Ardalis.GuardClauses;
using Newtonsoft.Json;

namespace CatStore.Domain.BasketAggregate;

public class BasketItem 
{
    public Guid Id { get; set; }
    public decimal UnitPrice { get; set; }
    
    public Guid CatId { get; set; }
    
    public int Quantity { get; set; }
    

    
    [JsonConstructor]
    public BasketItem(Guid id, Guid catId, int quantity,  decimal unitPrice)
    {
        Id = id;
        CatId = catId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
    
    public static BasketItem Create(Guid catId, int quantity, decimal unitPrice) =>
        new BasketItem(Guid.NewGuid(), catId, quantity, unitPrice);
    
    public void AddQuantity(int quantity)
    {
        Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

        Quantity += quantity;
    }

    public void DecreaseQuantity() => Quantity -= 1;
    
}