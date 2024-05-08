namespace Application.IRepositories;

public interface IBrandRepository
{
    Task<IEnumerable<BrandEntity>> GetAllAsync();
    Task<BrandEntity?> GetByIdAsync(int brandId);
    
    Task CreateAsync(BrandEntity entity);
    Task UpdateAsync(BrandEntity entity);
    Task DeleteAsync(BrandEntity entity);
    
    Task<bool> IsExistForUpdateByNameAsync(int brandId, string name);
    Task<bool> IsExistByNameAsync(string name);
}