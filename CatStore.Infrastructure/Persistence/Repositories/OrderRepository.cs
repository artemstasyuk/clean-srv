using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace CatStore.Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;

    public OrderRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    
    public async Task CreateAsync(Order order)
    {
        await _dbContext.AddAsync(order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Order order)
    {
        _dbContext.Remove(order);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<List<Order>> GetListAsync() => await _dbContext.Orders.ToListAsync();
    
    public async Task<List<Order>> GetListByUserIdAsync(Guid userId) =>
        await _dbContext.Orders.Include(el => el.OrderItems).
            Where(el => el.UserId == userId).ToListAsync();
    
    public async Task<Order?> GetByIdAsync(Guid id) =>
        await _dbContext.Orders.SingleOrDefaultAsync(el => el.Id == id);

}