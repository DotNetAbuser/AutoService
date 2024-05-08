namespace Domain.Configurations;

public class StatusConfiguration 
    : IEntityTypeConfiguration<StatusEntity>
{
    public void Configure(EntityTypeBuilder<StatusEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder
            .HasMany(x => x.Requests)
            .WithOne(x => x.Status);

        builder.HasData(new List<StatusEntity>
        {
            new()
            {
                Id = 1,
                Name = "В ожидание"
            },
            new()
            {
                Id = 2,
                Name = "Подтверждена"
            },
            new()
            {
                Id = 3,
                Name = "Закончена"
            }
        });
    }
}