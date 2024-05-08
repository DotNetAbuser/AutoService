namespace Domain.Configurations;

public class ModelConfiguration 
    : IEntityTypeConfiguration<ModelEntity>
{
    public void Configure(EntityTypeBuilder<ModelEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder
            .HasOne(x => x.Brand)
            .WithMany(x => x.Models)
            .HasForeignKey(x => x.BrandId);
        builder
            .HasMany(x => x.Requests)
            .WithOne(x => x.Model);
        
        builder.HasData(new List<ModelEntity>
        {
            new()
            {
                Id = 1,
                BrandId = 1,
                Name = "100"
            },
            new()
            {
                Id = 2,
                BrandId = 1,
                Name = "80"
            },
            new()
            {
                Id = 3,
                BrandId = 1,
                Name = "A3"
            },
            
            new()
            {
                Id = 4,
                BrandId = 2,
                Name = "1 серия"
            },
            new()
            {
                Id = 5,
                BrandId = 2,
                Name = "2 серия"
            },
            new()
            {
                Id = 6,
                BrandId = 2,
                Name = "3 серия"
            },
            
            new()
            {
                Id = 7,
                BrandId = 3,
                Name = "Amulet"
            },
            new()
            {
                Id = 8,
                BrandId = 3,
                Name = "Bonus"
            },
            new()
            {
                Id = 9,
                BrandId = 3,
                Name = "Fora"
            },
            
            new()
            {
                Id = 10,
                BrandId = 4,
                Name = "Aveo"
            },
            new()
            {
                Id = 11,
                BrandId = 4,
                Name = "Captiva"
            },
            new()
            {
                Id = 12,
                BrandId = 4,
                Name = "Cobalt"
            },
        });
    }
}