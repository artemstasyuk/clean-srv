using CatStore.Domain.CatAggregate;

namespace CatStore.Application.Common.Interfaces.Persistence;

public interface ICatRepository
{
    Task CreateAsync(Cat cat);
    Task<List<Cat>> GetListAsync();
    Task DeleteAsync(Cat cat);
    Task<Cat?> GetByIdAsync(Guid id);
    Task UpdateAsync(Cat cat);
}