namespace Domain.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Email)
            .IsUnique();
        builder
            .HasIndex(x => x.PhoneNumber)
            .IsUnique();

        builder
            .HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleID);
        builder
            .HasMany(x => x.Sessions)
            .WithOne(x => x.User);
        builder
            .HasMany(x => x.Requests)
            .WithOne(x => x.User);
    }
}