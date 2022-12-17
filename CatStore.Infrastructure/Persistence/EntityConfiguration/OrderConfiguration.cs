using System.Text.Json;
using CatStore.Domain.OrderAggregate;
using CatStore.Domain.OrderAggregate.ValuesObject;
using CatStore.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatStore.Infrastructure.Persistence.EntityConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {

        builder.ToTable("orders");

        builder.Property(o => o.Id).IsRequired();
        builder.Property(o => o.UserId).IsRequired();
        builder.Property(e => e.Address)
            .HasConversion(
                v => JsonSerializer.Serialize(v, null as JsonSerializerOptions),
                v => JsonSerializer.Deserialize<Address>(v, null as JsonSerializerOptions)!);
        builder.Property(o => o.Created).IsRequired();
        builder.Property(o => o.IsShipped).IsRequired();
        builder.Property(o => o.TotalPrice).IsRequired();
    }
}