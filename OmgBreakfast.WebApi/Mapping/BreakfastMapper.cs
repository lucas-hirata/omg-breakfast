using OmgBreakfast.ApiContracts.Breakfast;
using OmgBreakfast.Data.Models;

namespace OmgBreakfast.WebApi.Mapping;

public static class BreakfastMapper
{
    public static Breakfast MapToBreakfast(this CreateBreakfastRequest request) => new Breakfast(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);

    public static Breakfast MapToBreakfast(this UpsertBreakfastRequest request) => new Breakfast(
        request.Name,
        request.Description,
        request.StartDateTime,
        request.EndDateTime,
        DateTime.UtcNow,
        request.Savory,
        request.Sweet);

    public static BreakfastResponse MapToBreakfastResponse(this Breakfast breakfast) => new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet);
}
