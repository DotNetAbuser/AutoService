namespace Client.Infrastructure.Managers;

public interface IBrandManager
{
    Task<IResult<IEnumerable<BrandResponse>>> GetAllAsync();
    Task<IResult<BrandResponse>> GetByIdAsync(int brandId);
    Task<IResult> CreateAsync(CreateBrandRequest request);
    Task<IResult> UpdateAsync(int brandId, UpdateBrandRequest request);
    Task<IResult> DeleteAsync(int brandId);
}

public class BrandManager(
    IHttpClientFactory factory)
    : IBrandManager
{
    public async Task<IResult<IEnumerable<BrandResponse>>> GetAllAsync()
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(BrandRoutes.GetAll);
        return await response.ToResultAsync<IEnumerable<BrandResponse>>();
    }

    public async Task<IResult<BrandResponse>> GetByIdAsync(int brandId)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(BrandRoutes.GetById(brandId));
        return await response.ToResultAsync<BrandResponse>();
    }

    public async Task<IResult> CreateAsync(CreateBrandRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(BrandRoutes.Create, request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> UpdateAsync(int brandId, UpdateBrandRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PutAsJsonAsync(BrandRoutes.Update(brandId), request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> DeleteAsync(int brandId)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .DeleteAsync(BrandRoutes.Delete(brandId));
        return await response.ToResultAsync();
    }
}