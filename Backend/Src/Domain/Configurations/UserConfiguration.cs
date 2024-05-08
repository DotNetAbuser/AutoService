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
            .HasForeignKey(x => x.RoleId);
        builder
            .HasMany(x => x.Sessions)
            .WithOne(x => x.User);
        builder
            .HasMany(x => x.Requests)
            .WithOne(x => x.User);

        builder.HasData(new List<UserEntity>
        {
            new()
            {
                Id = Guid.NewGuid(),
                RoleId = (int)Role.Guest,
                LastName = "Устюшкин",
                FirstName = "Даниил",
                Email = "danilguest@gmail.com",
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword("qwerty123"),
                PhoneNumber = "+792281337228"
            },
            new()
            {
                Id = Guid.NewGuid(),
                RoleId = (int)Role.Operator,
                LastName = "Устюшкин",
                FirstName = "Даниил",
                Email = "daniloperator@gmail.com",
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword("qwerty123"),
                PhoneNumber = "+792281337227"
            },
            new()
            {
                Id = Guid.NewGuid(),
                RoleId = (int)Role.Admin,
                LastName = "Устюшкин",
                FirstName = "Даниил",
                Email = "daniladmin@gmail.com",
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword("qwerty123"),
                PhoneNumber = "+792281337229"
            }
        });
    }
}