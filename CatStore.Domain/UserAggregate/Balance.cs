using CatStore.Domain.UserAggregate.Enums;

namespace CatStore.Domain.UserAggregate;

public class Balance
{
    public Currency Currency { get; private set; }
    
    public decimal Amount { get; private set; }

    private Balance(Currency currency, decimal amount)
    {
        Currency = currency;
        Amount = amount;
    }

    public static Balance Create(Currency currency, decimal amount) => 
        new Balance(currency, amount);


}