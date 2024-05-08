namespace Application.IServices;

public interface IModelService
{
    Task<Result<IEnumerable<ModelResponse>>> GetAllByBrandIdAsync(int brandId);
    Task<Result<ModelResponse>> GetByIdAsync(int modelId);
    Task<Result> CreateAsync(CreateModelRequest request);

    Task<Result> UpdateAsync(int modelId, UpdateModelRequest request);
    
    Task<Result> DeleteAsync(int modelId);
}