using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email is already in use");

        public static Error InvalidDescription => Error.Validation(
            code: "User.InvalidDescription",
            description: "User description must be at least");
        public static Error NotFound => Error.NotFound(
            code: "User.NotFound",
            description: "User not found");
    }
}