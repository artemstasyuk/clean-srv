namespace CatStore.Domain.OrderAggregate;

public class Address
{
    public string Country { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string HouseNumber { get; private set; }

    private Address(string country, string city, string street, string houseNumber)
    {
        Country = country;
        City = city;
        Street = street;
        HouseNumber = houseNumber;
    }

    public static Address Create(string country, string city, string street, string houseNumber) => 
        new(country, city,  street, houseNumber);
    
}