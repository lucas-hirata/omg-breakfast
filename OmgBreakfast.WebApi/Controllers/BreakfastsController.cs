using ErrorOr;

using Microsoft.AspNetCore.Mvc;

using OmgBreakfast.ApiContracts.Breakfast;
using OmgBreakfast.BLL.Services.Breakfasts;
using OmgBreakfast.Data.Models;
using OmgBreakfast.WebApi.Mapping;

namespace OmgBreakfast.WebApi.Controllers;

[Produces("application/json")]
public class BreakfastsController(
    IBreakfastService breakfastService
    ) : ApiController
{
    private readonly IBreakfastService _breakfastService = breakfastService;

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
    public async Task<IActionResult> CreateBreakfast([FromBody] CreateBreakfastRequest request)
    {
        var breakfast = request.MapToBreakfast();

        var result = await _breakfastService.CreateBreakfastAsync(breakfast);

        if (result.IsError)
        {
            return Problem(result.Errors);
        }

        var response = breakfast.MapToBreakfastResponse();

        return CreatedAtGetBreakfast(breakfast.Id, response);
    }

    private IActionResult CreatedAtGetBreakfast(Guid id, BreakfastResponse response)
    {
        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new { id = id },
            value: response);
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
    public async Task<IActionResult> GetBreakfast(Guid id)
    {
        ErrorOr<Breakfast> result = await _breakfastService.GetBreakfastAsync(id);

        if (result.IsError)
        {
            return Problem(result.Errors);
        }

        var breakfast = result.Value;
        BreakfastResponse response = breakfast.MapToBreakfastResponse();

        return Ok(response);
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
    /// <response code="201">Returns the newly upserted breakfast</response>
    /// <response code="204">If the breakfast was successfully updated</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">Unexpected error</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpsertBreakfast(Guid id, [FromBody] UpsertBreakfastRequest request)
    {
        var breakfast = request.MapToBreakfast();

        var result = await _breakfastService.UpsertBreakfastAsync(breakfast);

        if (result.IsError)
        {
            return Problem(result.Errors);
        }

        if (result.Value.IsNewlyCreated)
        {
            var response = breakfast.MapToBreakfastResponse();
            return CreatedAtGetBreakfast(breakfast.Id, response);
        }

        return NoContent();
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
    public async Task<IActionResult> DeleteBreakfast(Guid id)
    {
        var result = await _breakfastService.DeleteBreakfastAsync(id);

        if (result.IsError)
        {
            return Problem(result.Errors);
        }

        return NoContent();
    }
}
