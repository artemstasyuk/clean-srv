using CatStore.Domain.UserAggregate;
using CatStore.Domain.UserAggregate.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatStore.Infrastructure.Persistence.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    private List<User> _users = new()
    {

        // Test snippets 
        User.Create("Artem", "Admin", "admin@gmail.com", "admin",
            Balance.Create(Currency.Euro, 1000), Role.Admin),
        User.Create("Joe", "Biden", "joe@gmail.com", "joe",
            Balance.Create(Currency.Euro, 100), Role.Customer), 
    };
    
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.ToTable("users");
        
        builder.Property(user => user.Id).IsRequired();
        builder.Property(c => c.FirstName).IsRequired();
        builder.Property(c => c.LastName).IsRequired();
        builder.Property(c => c.Email).IsRequired();
        builder.Property(c => c.Password).IsRequired();
        builder.Property(c => c.Role).IsRequired();
        builder.Property(c => c.Balance)
            .HasConversion(
                amount => amount.Amount,
                
                

            .IsRequired();
        builder.Property(c => c.CreatedDateTime).IsRequired();
        builder.Property(c => c.UpdatedDateTime).IsRequired();

        builder.HasData(_users);
    }
}