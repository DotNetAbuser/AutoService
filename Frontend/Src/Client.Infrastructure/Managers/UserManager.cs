namespace Client.Infrastructure.Managers;

public interface IUserManager
{
    Task<IResult<PaginatedData<UserResponse>>> GetPaginatedUsersAsync(
        int pageNumber, int pageSize, string? searchTerms);
    Task<IResult<UserResponse>> GetByIdAsync(Guid userId);
    Task<IResult> SignUpAsync(SignUpRequest request);
}

public class UserManager(
    IHttpClientFactory factory)
    : IUserManager
{
    public async Task<IResult<PaginatedData<UserResponse>>> GetPaginatedUsersAsync(int pageNumber, int pageSize, string? searchTerms)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(UserRoutes.GetPaginatedUsers(pageNumber, pageSize, searchTerms));
        return await response.ToResultAsync<PaginatedData<UserResponse>>();
    }

    public async Task<IResult<UserResponse>> GetByIdAsync(Guid userId)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(UserRoutes.GetById(userId));
        return await response.ToResultAsync<UserResponse>();
    }

    public async Task<IResult> SignUpAsync(SignUpRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(UserRoutes.SignUp, request);
        return await response.ToResultAsync();
    }
}