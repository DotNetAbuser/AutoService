namespace Application.IServices;

public interface IBrandService
{
    Task<Result<IEnumerable<BrandResponse>>> GetAllAsync();
    Task<Result<BrandResponse>> GetByIdAsync(int brandId);
    Task<Result> CreateAsync(CreateBrandRequest request);
    Task<Result> UpdateAsync(int brandId, UpdateBrandRequest request);
    Task<Result> DeleteAsync(int brandId);
}