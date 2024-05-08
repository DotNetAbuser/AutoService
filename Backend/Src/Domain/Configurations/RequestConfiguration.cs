namespace Domain.Configurations;

public class RequestConfiguration 
    : IEntityTypeConfiguration<RequestEntity>
{
    public void Configure(EntityTypeBuilder<RequestEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Requests)
            .HasForeignKey(x => x.UserId);
        builder
            .HasOne(x => x.Brand)
            .WithMany(x => x.Requests)
            .HasForeignKey(x => x.BrandId);
        builder
            .HasOne(x => x.Model)
            .WithMany(x => x.Requests)
            .HasForeignKey(x => x.ModelId);
        builder
            .HasOne(x => x.ServiceType)
            .WithMany(x => x.Requests)
            .HasForeignKey(x => x.ServiceTypeId);
    }
}