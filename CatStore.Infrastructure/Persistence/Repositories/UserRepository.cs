using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace CatStore.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User?> GetByEmailAsync(string email) =>
       await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
    
    public async Task<User?> GetByIdAsync(Guid id) =>
        await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    

    public async Task<User> CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        return user;
    }
    
}