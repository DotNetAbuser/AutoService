namespace Infrastructure.Repositories;

public class BrandRepository(
    ApplicationDbContext _dbContext)
    : IBrandRepository
{
    public async Task<IEnumerable<BrandEntity>> GetAllAsync()
    {
        return await _dbContext.Brands
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<BrandEntity?> GetByIdAsync(int brandId)
    {
        return await _dbContext.Brands
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == brandId);
    }

    public async Task CreateAsync(BrandEntity entity)
    {
        await _dbContext.Brands.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(BrandEntity entity)
    {
        _dbContext.Brands.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(BrandEntity entity)
    {
        _dbContext.Brands.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExistForUpdateByNameAsync(int brandId, string name)
    {
        return await _dbContext.Brands
            .AsNoTracking()
            .AnyAsync(x => x.Id == brandId && x.Name == name);
    }

    public async Task<bool> IsExistByNameAsync(string name)
    {
        return await _dbContext.Brands
            .AsNoTracking()
            .AnyAsync(x => x.Name == name);
    }
}