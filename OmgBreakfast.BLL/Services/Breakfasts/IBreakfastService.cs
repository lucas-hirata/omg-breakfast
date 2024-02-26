using ErrorOr;

using OmgBreakfast.BLL.ServiceResults;
using OmgBreakfast.Data.Models;

namespace OmgBreakfast.BLL.Services.Breakfasts;

public interface IBreakfastService
{
    Task<ErrorOr<Created>> CreateBreakfastAsync(Breakfast breakfast);
    Task<ErrorOr<Upserted>> UpsertBreakfastAsync(Breakfast breakfast);
    Task<ErrorOr<Deleted>> DeleteBreakfastAsync(Guid id);
    Task<ErrorOr<Breakfast>> GetBreakfastAsync(Guid id);
}
