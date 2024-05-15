namespace Client.Infrastructure.Managers;

public interface IModelManager
{
    Task<IResult<IEnumerable<ModelResponse>>> GetAllByBrandIdAsync(int brandId);
    Task<IResult<ModelResponse>> GetByIdAsync(int modelId);
    Task<IResult> CreateAsync(CreateModelRequest request);

    Task<IResult> UpdateAsync(int modelId, UpdateModelRequest request);
    
    Task<IResult> DeleteAsync(int modelId);
}

public class ModelManager(
    IHttpClientFactory factory)
    : IModelManager
{
    public async Task<IResult<IEnumerable<ModelResponse>>> GetAllByBrandIdAsync(int brandId)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(ModelRoutes.GetAllModelsByBrandId(brandId));
        return await response.ToResultAsync<IEnumerable<ModelResponse>>();
    }

    public async Task<IResult<ModelResponse>> GetByIdAsync(int modelId)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(ModelRoutes.GetById(modelId));
        return await response.ToResultAsync<ModelResponse>();
    }

    public async Task<IResult> CreateAsync(CreateModelRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(ModelRoutes.Create, request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> UpdateAsync(int modelId, UpdateModelRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PutAsJsonAsync(ModelRoutes.Update(modelId), request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> DeleteAsync(int modelId)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .DeleteAsync(ModelRoutes.Delete(modelId));
        return await response.ToResultAsync();
    }
}