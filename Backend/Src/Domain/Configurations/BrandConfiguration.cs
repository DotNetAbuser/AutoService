namespace Domain.Configurations;

public class BrandConfiguration 
    : IEntityTypeConfiguration<BrandEntity>
{
    public void Configure(EntityTypeBuilder<BrandEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder
            .HasMany(x => x.Models)
            .WithOne(x => x.Brand);
        builder
            .HasMany(x => x.Requests)
            .WithOne(x => x.Brand);

        var defaultBrands = new List<BrandEntity>
        {
            new()
            {
                Id = 1,
                Name = "Audi"
            },
            new()
            {
                Id = 2,
                Name = "BMW"
            },
            new()
            {
                Id = 3,
                Name = "Chery"
            },
            new()
            {
                Id = 4,
                Name = "Chevrolet"
            }
        };
        builder.HasData(defaultBrands);
    }
}