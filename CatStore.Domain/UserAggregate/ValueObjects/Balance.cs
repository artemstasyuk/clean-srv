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
        new(currency, amount);
    
    public void Replenishment(decimal balance) => Amount += balance;

    public void Debit(decimal balance) => Amount -= balance;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Currency;
        yield return Amount;
    }

}