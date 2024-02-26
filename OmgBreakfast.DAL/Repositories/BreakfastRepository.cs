using OmgBreakfast.Data.Models;

namespace OmgBreakfast.DAL.Repositories;
public class BreakfastRepository : IBreakfastRepository
{
    private static readonly Dictionary<Guid, Breakfast> _breakfasts = [];

    public async Task<Breakfast> AddBreakfastAsync(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
        return await Task.FromResult(breakfast);
    }

    public async Task<bool> BreakfastExistsAsync(Guid id)
    {
        return await Task.FromResult(_breakfasts.Any(x => x.Key == id));
    }

    public async Task DeleteBreakfastAsync(Guid id)
    {
        if (!await BreakfastExistsAsync(id))
        {
            throw new KeyNotFoundException($"Breakfast with id {id} not found");
        }

        _breakfasts.Remove(id);
    }

    public async Task<Breakfast> GetBreakfastByIdAsync(Guid id)
    {
        if(_breakfasts.TryGetValue(id, out var breakfast))
        {
            return await Task.FromResult(breakfast);
        }

        throw new KeyNotFoundException($"Breakfast with id {id} not found");
    }

    public async Task<IEnumerable<Breakfast>> GetBreakfastsAsync()
    {
        return await Task.FromResult(_breakfasts.Values);
    }

    public async Task<Breakfast> UpdateBreakfastAsync(Breakfast breakfast)
    {
        if (!_breakfasts.Any(x => x.Key == breakfast.Id))
        {
            throw new KeyNotFoundException($"Breakfast with id {breakfast.Id} not found");
        }

        _breakfasts[breakfast.Id] = breakfast;
        return await Task.FromResult(breakfast);
    }
}
