using ErrorOr;

namespace CatStore.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email already in use.");

        public static Error NotFound => Error.NotFound(
            code: "User.NotFound",
            description: "User not found.");
    }
}