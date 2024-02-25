using Microsoft.AspNetCore.Mvc;

using OmgBreakfast.Contracts.Breakfast;

namespace OmgBreakfast.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class BreakfastsController : ControllerBase
{
    /// <summary>
    /// Creates a breakfast.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>A newly created breakfast</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /breakfasts
    ///     {
    ///         "name": "Vegan Sunshine",
    ///         "description": "Vegan everything! Join us for a healthy breakfast..",
    ///         "startDateTime": "2022-04-08T08:00:00",
    ///         "endDateTime": "2022-04-08T11:00:00",
    ///         "savory": [
    ///             "Oatmeal",
    ///             "Avocado Toast",
    ///             "Omelette",
    ///             "Salad"
    ///         ],
    ///         "Sweet": [
    ///             "Cookie"
    ///         ]
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created breakfast</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">Unexpected error</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult CreateBreakfast([FromBody] CreateBreakfastRequest request)
    {
        return Ok(request);
    }

    /// <summary>
    /// Gets a breakfast.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>An existing breakfast</returns>
    /// <response code="200">Returns an existing breakfast</response>
    /// <response code="404">If the item is not found</response>
    /// <response code="500">Unexpected error</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetBreakfasts(Guid id)
    {
        return Ok(id);
    }

    /// <summary>
    /// Upserts a breakfast.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns>An upserted breakfast</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /breakfasts
    ///     {
    ///         "name": "Vegan Sunshine",
    ///         "description": "Vegan everything! Join us for a healthy breakfast..",
    ///         "startDateTime": "2022-04-08T08:00:00",
    ///         "endDateTime": "2022-04-08T11:00:00",
    ///         "savory": [
    ///             "Oatmeal",
    ///             "Avocado Toast",
    ///             "Omelette",
    ///             "Salad"
    ///         ],
    ///         "Sweet": [
    ///             "Cookie"
    ///         ]
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Returns the upserted breakfast</response>
    /// <response code="201">Returns the newly upserted breakfast</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">Unexpected error</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult UpsertBreakfast(Guid id, [FromBody] UpsertBreakfastRequest request)
    {
        return Ok(request);
    }

    /// <summary>
    /// Deletes a breakfast.
    /// </summary>
    /// <param name="id"></param>
    /// <response code="204">Successfully deleted breakfast</response>
    /// <response code="404">If the item is not found</response>
    /// <response code="500">Unexpected error</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult DeleteBreakfast(Guid id)
    {
        return Ok(id);
    }
}
