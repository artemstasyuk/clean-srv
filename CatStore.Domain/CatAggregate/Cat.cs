using CatStore.Domain.CatAggregate.Enums;

namespace CatStore.Domain.CatAggregate;

public class Cat
{
    
    public Guid Id { get; private set; }
    
    public string Name { get; private set; }
    
    public Sex Sex { get; private set; }
    
    public string ImageUrl { get; private set; }
    
    public decimal Price { get; private set; }
    
    public string Description { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }
    
    private Cat(Guid id, string name, Sex sex, string imageUrl, decimal price, 
        string description, DateTime createdDateTime, DateTime updatedDateTime)
    {
        Id = id;
        Sex = sex;
        Name = name;
        ImageUrl = imageUrl;
        Price = price;
        Description = description;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    
    public static Cat Create(string name, Sex sex, string imageUrl, decimal price, string description) =>
        new Cat(Guid.NewGuid(),  name, sex, imageUrl, price,description, DateTime.UtcNow, DateTime.UtcNow);

    public Cat Update(string name, Sex sex, string imageUrl, decimal price, string description)
    {
        Name = name;
        Sex = sex;
        ImageUrl = imageUrl;
        Price = price;
        Description = description;
        UpdatedDateTime = DateTime.Now;
        

        return this;
    }

}