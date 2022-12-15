using ErrorOr;

namespace CatStore.Domain.Common.Errors;

public static partial class Errors
{
    public static class Cat
    {
        public static Error NotFound => Error.NotFound(
            code: "Cat.NotFound",
            description: "NotFound Cat in Db.");
    }
}
