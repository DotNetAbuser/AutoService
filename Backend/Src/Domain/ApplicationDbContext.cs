namespace Domain;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<SessionEntity> Sessions { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    
    public DbSet<BrandEntity> Brands { get; set; }
    public DbSet<ModelEntity> Models { get; set; }
    public DbSet<ServiceTypeEntity> ServiceTypes { get; set; }
    public DbSet<RequestEntity> Requests { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}