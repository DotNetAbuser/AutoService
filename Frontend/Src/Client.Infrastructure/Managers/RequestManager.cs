namespace Client.Infrastructure.Managers;

public interface IRequestManager
{
    Task<IResult<PaginatedData<RequestResponse>>> GetPaginatedRequestsAsync(
        int pageNumber, int pageSize, string? searchTerms);
    Task<IResult<PaginatedData<RequestResponse>>> GetPaginatedRequestsByUserIdAsync(
        Guid userId, int pageNumber, int pageSize, string? searchTerms);
    Task<IResult<RequestResponse>> GetByIdAsync(Guid requestId);

    Task<IResult> CreateAsync(CreateRequestRequest request);
    Task<IResult> UpdateAsync(Guid requestId, UpdateRequestRequest request);
    Task<IResult> DeleteAsync(Guid requestId);
    Task<IResult> ChangeStatusAsync(Guid requestId, ChangeStatusRequest request);
}

public class RequestManager(
    IHttpClientFactory factory)
    : IRequestManager
{
    public async Task<IResult<PaginatedData<RequestResponse>>> GetPaginatedRequestsAsync(
        int pageNumber, int pageSize, string? searchTerms)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(RequestRoutes.GetPaginatedRequests(pageNumber, pageSize, searchTerms));
        return await response.ToResultAsync<PaginatedData<RequestResponse>>();
    }

    public async Task<IResult<PaginatedData<RequestResponse>>> GetPaginatedRequestsByUserIdAsync(
        Guid userId, int pageNumber, int pageSize, string? searchTerms)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(RequestRoutes.GetPaginatedRequestsByUserId(userId, pageNumber, pageSize, searchTerms));
        return await response.ToResultAsync<PaginatedData<RequestResponse>>();
    }

    public async Task<IResult<RequestResponse>> GetByIdAsync(Guid requestId)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(RequestRoutes.GetById(requestId));
        return await response.ToResultAsync<RequestResponse>();
    }

    public async Task<IResult> CreateAsync(CreateRequestRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(RequestRoutes.Create, request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> UpdateAsync(Guid requestId, UpdateRequestRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PutAsJsonAsync(RequestRoutes.Update(requestId), request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> DeleteAsync(Guid requestId)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .DeleteAsync(RequestRoutes.Delete(requestId));
        return await response.ToResultAsync();
    }

    public async Task<IResult> ChangeStatusAsync(Guid requestId, ChangeStatusRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PutAsJsonAsync(RequestRoutes.ChangeStatus(requestId), request);
        return await response.ToResultAsync();
    }
}