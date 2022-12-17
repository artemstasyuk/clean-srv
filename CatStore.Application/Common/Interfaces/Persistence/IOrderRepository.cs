using CatStore.Domain.OrderAggregate;

namespace CatStore.Application.Common.Interfaces.Persistence;

public interface IOrderRepository
{
    Task CreateAsync(Order order);
    Task DeleteAsync(Order order);
    Task<List<Order>> GetListAsync();
    Task<List<Order>> GetListByUserIdAsync(Guid userId);
    Task<Order?> GetByIdAsync(Guid id);
   
}