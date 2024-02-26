using ErrorOr;

namespace OmgBreakfast.BLL.ServiceErrors;

public static class Errors
{
    public static class Breakfast
    {
        public static Error NotFound => Error.NotFound(
            code: "Breakfast.NotFound",
            description: "Breakfast was not found.");
    }
}
