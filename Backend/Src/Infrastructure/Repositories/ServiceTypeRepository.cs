namespace Infrastructure.Repositories;

public class ServiceTypeRepository(
    ApplicationDbContext _dbContext)
    : IServiceTypeRepository
{
    public async Task<IEnumerable<ServiceTypeEntity>> GetAllAsync()
    {
        return await _dbContext.ServiceTypes
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ServiceTypeEntity?> GetByIdAsync(int serviceTypeId)
    {
        return await _dbContext.ServiceTypes
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == serviceTypeId);
    }

    public async Task CreateAsync(ServiceTypeEntity entity)
    {
        await _dbContext.ServiceTypes.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(ServiceTypeEntity entity)
    {
        _dbContext.ServiceTypes.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(ServiceTypeEntity entity)
    {
        _dbContext.ServiceTypes.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExistByNameAsync(string name)
    {
        return await _dbContext.ServiceTypes
            .AsNoTracking()
            .AnyAsync(x => x.Name == name);
    }

    public async Task<bool> IsExistByDescriptionAsync(string description)
    {
        return await _dbContext.ServiceTypes
            .AsNoTracking()
            .AnyAsync(x => x.Description == description);
    }

    public async Task<bool> IsExistForUpdateByNameAsync(int serviceTypeId, string name)
    {
        return await _dbContext.ServiceTypes
            .AsNoTracking()
            .AnyAsync(x => x.Id == serviceTypeId && x.Name == name);
    }

    public async Task<bool> IsExistForUpdateByDescriptionAsync(int serviceTypeId, string description)
    {
        return await _dbContext.ServiceTypes
            .AsNoTracking()
            .AnyAsync(x => x.Id == serviceTypeId && x.Name == description);
    }
}