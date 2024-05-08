namespace Application.IRepositories;

public interface IServiceTypeRepository
{
    Task<IEnumerable<ServiceTypeEntity>> GetAllAsync();
    Task<ServiceTypeEntity?> GetByIdAsync(int serviceTypeId);
    
    Task CreateAsync(ServiceTypeEntity entity);
    Task UpdateAsync(ServiceTypeEntity entity);
    Task DeleteAsync(ServiceTypeEntity entity);
    
    Task<bool> IsExistByNameAsync(string name);
    Task<bool> IsExistByDescriptionAsync(string description);
    Task<bool> IsExistForUpdateByNameAsync(int serviceTypeId, string name);
    Task<bool> IsExistForUpdateByDescriptionAsync(int serviceTypeId, string description);
}