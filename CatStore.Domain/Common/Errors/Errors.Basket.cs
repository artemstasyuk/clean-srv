using ErrorOr;

namespace CatStore.Domain.Common.Errors;

public static partial class Errors
{
    public static class Basket
    {
        public static Error ItemNotFound => Error.NotFound(
            code: "Basket.NotFound",
            description: "Item not found in basket.");
        
        public static Error BasketEmpty => Error.Conflict(
            code: "basket.Empty",
            description: "basket is empty.");
    }
}