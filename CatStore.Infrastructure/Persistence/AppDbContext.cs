using CatStore.Domain.CatAggregate;
using CatStore.Domain.OrderAggregate;
using CatStore.Domain.OrderAggregate.Entity;
using CatStore.Domain.UserAggregate;
using CatStore.Infrastructure.Persistence.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CatStore.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Cat> Cats { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<OrderItem> OrderItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CatConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
}