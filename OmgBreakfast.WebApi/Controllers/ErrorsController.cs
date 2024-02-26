using Microsoft.AspNetCore.Mvc;

namespace OmgBreakfast.WebApi.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error() => Problem();
}
