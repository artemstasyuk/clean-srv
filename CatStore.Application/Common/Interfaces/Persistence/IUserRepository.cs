using CatStore.Domain.UserAggregate;

namespace CatStore.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User> CreateAsync(User user);

    Task<User?> GetByIdAsync(Guid id);
}