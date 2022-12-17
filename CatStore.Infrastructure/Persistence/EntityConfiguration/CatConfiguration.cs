using CatStore.Domain.CatAggregate;
using CatStore.Domain.CatAggregate.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatStore.Infrastructure.Persistence.EntityConfiguration;

public class CatConfiguration : IEntityTypeConfiguration<Cat>
{ 
    private readonly List<Cat> _cats = new()
    {
        //Test snippets
        Cat.Create("FatCat",  Sex.Female,string.Empty, 3, "Just a fat cat"),
        Cat.Create("BigCat", Sex.Male,string.Empty,2,"Just a very big cat"),
        Cat.Create("DedCat", Sex.Male,string.Empty,1,"Just a zombie cat"),
        Cat.Create("GamerCat", Sex.Male,string.Empty,  4,"Often play Dota2"),
        Cat.Create("ArinaCat", Sex.Female, string.Empty, 1, "Just a fat femenistic cat")
    };
    
    public void Configure(EntityTypeBuilder<Cat> builder)
    {
        builder.ToTable("cats");

        builder.Property(c => c.Id).IsRequired();
        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.Price).IsRequired();
        builder.Property(c => c.Description).IsRequired();
        builder.Property(c => c.CreatedDateTime).IsRequired();
        builder.Property(c => c.UpdatedDateTime).IsRequired();

        builder.HasData(_cats);
    }
}