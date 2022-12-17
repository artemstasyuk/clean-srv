namespace CatStore.Domain.BasketAggregate;

public class Basket 
{
    private readonly List<BasketItem> _items = new();
    
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public int ItemsAmount => _items.Count();
    
    public decimal TotalPrice => CalculateTotalPrice;

    public IReadOnlyList<BasketItem> Items => _items.AsReadOnly();

    public decimal CalculateTotalPrice => _items.Sum(i => i.UnitPrice * i.Quantity);
    public Basket(Guid id, Guid userId)
    {
        Id = id;
        UserId = userId;
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
    
    public void DecreaseItemQuantity(Guid catId)
    {
        var item = Items.First(itm => itm.CatId == catId);
        if (item.Quantity == 1) _items.Remove(item);
        item.DecreaseQuantity();
    }

    public void RemoveItem(Guid catId)
    {
        var item = Items.First(itm => itm.CatId == catId);
        _items.Remove(item);
    }
    
    public void Clear() => _items.Clear();

}