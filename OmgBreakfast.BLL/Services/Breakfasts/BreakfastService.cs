using ErrorOr;

using OmgBreakfast.BLL.ServiceErrors;
using OmgBreakfast.BLL.ServiceResults;
using OmgBreakfast.DAL.Repositories;
using OmgBreakfast.Data.Models;

namespace OmgBreakfast.BLL.Services.Breakfasts;

public class BreakfastService(
    IBreakfastRepository breakfastRepository
    ) : IBreakfastService
{
    private readonly IBreakfastRepository _breakfastRepository = breakfastRepository;

    public async Task<ErrorOr<Created>> CreateBreakfastAsync(Breakfast breakfast)
    {
        await _breakfastRepository.AddBreakfastAsync(breakfast);
        return Result.Created;
    }

    public async Task<ErrorOr<Deleted>> DeleteBreakfastAsync(Guid id)
    {
        await _breakfastRepository.DeleteBreakfastAsync(id);
        return Result.Deleted;
    }

    public async Task<ErrorOr<Breakfast>> GetBreakfastAsync(Guid id)
    {
        try
        {
            return await _breakfastRepository.GetBreakfastByIdAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return Errors.Breakfast.NotFound;
        }
    }

    public async Task<ErrorOr<Upserted>> UpsertBreakfastAsync(Breakfast breakfast)
    {
        var breakfastExists = await _breakfastRepository.BreakfastExistsAsync(breakfast.Id);

        if (breakfastExists)
        {
            await UpdateBreakfastAsync(breakfast);
        }
        else
        {
            await CreateBreakfastAsync(breakfast);
        }

        return new Upserted(!breakfastExists);
    }

    private async Task<ErrorOr<Updated>> UpdateBreakfastAsync(Breakfast breakfast)
    {
        try
        {
            await _breakfastRepository.UpdateBreakfastAsync(breakfast);
            return Result.Updated;
        }
        catch (KeyNotFoundException)
        {
            return Errors.Breakfast.NotFound;
        }
    }
}
