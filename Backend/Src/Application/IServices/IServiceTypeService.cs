namespace Application.IServices;

public interface IServiceTypeService
{
    Task<Result<IEnumerable<ServiceTypeResponse>>> GetAllAsync();
    Task<Result<ServiceTypeResponse>> GetByIdAsync(int serviceTypeId);
    Task<Result> CreateAsync(CreateServiceTypeRequest request);
    Task<Result> UpdateAsync(int serviceTypeId, UpdateServiceTypeRequest request);
    Task<Result> DeleteAsync(int serviceTypeId);
}