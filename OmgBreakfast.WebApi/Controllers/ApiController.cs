using ErrorOr;

using Microsoft.AspNetCore.Mvc;

namespace OmgBreakfast.WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        var firstError = errors.FirstOrDefault();

        var statusCode = firstError.Type switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(
            title: firstError.Description,
            statusCode: statusCode);
    }
}
