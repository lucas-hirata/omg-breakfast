using OmgBreakfast.Data.Models;

namespace OmgBreakfast.DAL.Repositories;

public  interface IBreakfastRepository
{
    Task<IEnumerable<Breakfast>> GetBreakfastsAsync();
    Task<Breakfast> GetBreakfastByIdAsync(Guid id);
    Task<Breakfast> AddBreakfastAsync(Breakfast breakfast);
    Task<Breakfast> UpdateBreakfastAsync(Breakfast breakfast);
    Task DeleteBreakfastAsync(Guid id);
    Task<bool> BreakfastExistsAsync(Guid id);
}
