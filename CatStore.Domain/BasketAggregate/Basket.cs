using Newtonsoft.Json;

namespace CatStore.Domain.BasketAggregate;

public class Basket 
{
    private readonly List<BasketItem> _items = new();
    
    public Guid Id { get; private set; }
    
    public Guid UserId { get; private set; }

    public int ItemsAmount {
        get => _items.Count;
        init { if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value)); }
    }

    public decimal TotalPrice {
        get => CalculateTotalPrice();
        init { if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value)); }
    }

    public IReadOnlyList<BasketItem> Items => _items.AsReadOnly();

    public decimal CalculateTotalPrice() => _items.Sum(i => i.UnitPrice * i.Quantity);


    public Basket(Guid id, Guid userId)
    {
        Id = id;
        UserId = userId;
    }
    
    [JsonConstructor]
    public Basket(Guid id, Guid userId,int itemsAmount, decimal totalPrice, List<BasketItem> items)
    {
        Id = id;
        UserId = userId;
        ItemsAmount = itemsAmount;
        TotalPrice = totalPrice;
        _items = items;
    }

    public static Basket Create(Guid userId) =>
        new Basket(Guid.NewGuid(), userId);

    public void AddItem(Guid catId, decimal unitPrice, int quantity)
    {
        if (!Items.Any(itm => itm.CatId == catId)){
            _items.Add(BasketItem.Create(catId, quantity, unitPrice));
            return;
        }
        var existingItem = Items.First(itm => itm.CatId == catId);
        existingItem.AddQuantity(quantity);
    }
    

    public void RemoveItem(Guid itemId)
    {
        var item = Items.First(itm => itm.Id == itemId);
        _items.Remove(item);
    }
    
    public void Clear() => _items.Clear();

}