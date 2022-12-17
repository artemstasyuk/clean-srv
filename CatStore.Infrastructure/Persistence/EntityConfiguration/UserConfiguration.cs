using System.Text.Json;
using CatStore.Domain.UserAggregate;
using CatStore.Domain.UserAggregate.Enums;
using CatStore.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

 namespace CatStore.Infrastructure.Persistence.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    private List<User> _users = new()
    {

        // Test snippets 
        User.Create("Artem", "Admin", "admin@gmail.com", BCrypt.Net.BCrypt.HashPassword("admin2007"),
            Balance.Create(Currency.Euro, 1000), Role.Admin),
        User.Create("Joe", "Biden", "joe@gmail.com", BCrypt.Net.BCrypt.HashPassword("joe2004"),
            Balance.Create(Currency.Euro, 100), Role.Customer), 
    };
    
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.ToTable("users");
        
        builder.Property(u => u.Balance)
            .HasConversion(
                v => JsonSerializer.Serialize(v, null as JsonSerializerOptions),
                v => JsonSerializer.Deserialize<Balance>(v, null as JsonSerializerOptions)!);
        builder.Property(u => u.Id).IsRequired();
        builder.Property(u => u.FirstName).IsRequired();
        builder.Property(u => u.LastName).IsRequired();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.Password).IsRequired();
        builder.Property(u => u.Role).IsRequired();
        builder.Property(u => u.CreatedDateTime).IsRequired();
        builder.Property(u => u.UpdatedDateTime).IsRequired();

        builder.HasData(_users);
    }
}