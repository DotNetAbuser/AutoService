namespace Application.IRepositories;

public interface IModelRepository
{
    Task<IEnumerable<ModelEntity>> GetAllByBrandIdAsync(int brandId);
    Task<ModelEntity?> GetByIdAsync(int modelId);
    
    Task CreateAsync(ModelEntity entity);
    Task UpdateAsync(ModelEntity entity);
    Task DeleteAsync(ModelEntity entity);
    
    Task<bool> IsExistByNameAsync(string name);
    Task<bool> IsExistForUpdateByNameAsync(int modelId, string name);
}