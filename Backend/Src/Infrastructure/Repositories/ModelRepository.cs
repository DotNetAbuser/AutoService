namespace Infrastructure.Repositories;

public class ModelRepository(
    ApplicationDbContext _dbContext)
    : IModelRepository
{
    public async Task<IEnumerable<ModelEntity>> GetAllByBrandIdAsync(int brandId)
    {
        return await _dbContext.Models
            .AsNoTracking()
            .Where(x => x.BrandId == brandId)
            .ToListAsync();
    }

    public async Task<ModelEntity?> GetByIdAsync(int modelId)
    {
        return await _dbContext.Models
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == modelId);
    }

    public async Task CreateAsync(ModelEntity entity)
    {
        await _dbContext.Models.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(ModelEntity entity)
    {
        _dbContext.Models.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(ModelEntity entity)
    {
        _dbContext.Models.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExistByNameAsync(string name)
    {
        return await _dbContext.Models
            .AsNoTracking()
            .AnyAsync(x => x.Name == name);
    }

    public async Task<bool> IsExistForUpdateByNameAsync(int modelId, string name)
    {
        return await _dbContext.Models
            .AsNoTracking()
            .AnyAsync(x => x.Id == modelId && x.Name == name);
    }
}