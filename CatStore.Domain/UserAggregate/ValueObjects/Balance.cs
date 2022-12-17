using CatStore.Domain.Common.Models;
using CatStore.Domain.UserAggregate.Enums;

namespace CatStore.Domain.UserAggregate.ValueObjects;

public class Balance : ValueObject
{
    public Currency Currency { get; private set; }
    
    public decimal Amount { get; private set; }

    public Balance(Currency  currency, decimal amount)
    {
        Currency = currency;
        Amount = amount;
    }

    public static Balance Create(Currency currency, decimal amount) => 
        new Balance(currency, amount);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Currency;
        yield return Amount;
    }


}