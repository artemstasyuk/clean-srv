using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.CatAggregate;
using Microsoft.EntityFrameworkCore;

namespace CatStore.Infrastructure.Persistence.Repositories;

public class CatRepository : ICatRepository
{
    private readonly AppDbContext _dbContext;

    public CatRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Cat cat)
    {
        await _dbContext.AddAsync(cat);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Cat cat)
    {
        _dbContext.Remove(cat);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Cat>> GetListAsync() => await _dbContext.Cats.ToListAsync();

    public async Task<Cat?> GetByIdAsync(Guid id) =>
        await _dbContext.Cats.SingleOrDefaultAsync(el => el.Id == id);

    public async Task UpdateAsync(Cat cat)
    {
        _dbContext.Update(cat);
        await _dbContext.SaveChangesAsync();
    }
}
    