using ErrorOr;

namespace CatStore.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email already in use.");
        
        public static Error DuplicatePassword => Error.Conflict(
            code: "User.DuplicatePassword",
            description: "your password is the same as the previous one.");

        public static Error NotFound => Error.NotFound(
            code: "User.NotFound",
            description: "User not found.");
        
        public static Error NotEnoughBalance => Error.Validation(
            code: "User.NotEnoughBalance",
            description: "Not enough balance on account.");
    }
}