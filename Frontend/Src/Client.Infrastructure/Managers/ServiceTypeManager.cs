namespace Client.Infrastructure.Managers;

public interface IServiceTypeManager
{
    Task<IResult<IEnumerable<ServiceTypeResponse>>> GetAllAsync();
    Task<IResult<ServiceTypeResponse>> GetByIdAsync(int serviceTypeId);
    Task<IResult> CreateAsync(CreateServiceTypeRequest request);
    Task<IResult> UpdateAsync(int serviceTypeId, UpdateServiceTypeRequest request);
    Task<IResult> DeleteAsync(int serviceTypeId);
}

public class ServiceTypeManager(
    IHttpClientFactory factory)
    : IServiceTypeManager
{
    public async Task<IResult<IEnumerable<ServiceTypeResponse>>> GetAllAsync()
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(ServiceTypeRoutes.GetAll);
        return await response.ToResultAsync<IEnumerable<ServiceTypeResponse>>();
    }

    public async Task<IResult<ServiceTypeResponse>> GetByIdAsync(int serviceTypeId)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(ServiceTypeRoutes.GetById(serviceTypeId));
        return await response.ToResultAsync<ServiceTypeResponse>();
    }

    public async Task<IResult> CreateAsync(CreateServiceTypeRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(ServiceTypeRoutes.Create, request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> UpdateAsync(int serviceTypeId, UpdateServiceTypeRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PutAsJsonAsync(ServiceTypeRoutes.Update(serviceTypeId), request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> DeleteAsync(int serviceTypeId)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .DeleteAsync(ServiceTypeRoutes.Delete(serviceTypeId));
        return await response.ToResultAsync();
    }
}