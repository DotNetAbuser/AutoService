namespace Client.Infrastructure.Routes;

public static class UserRoutes
{
    private const string BaseUrl = "api/identity/user";

    public static string GetPaginatedUsers(
        int pageNumber, int pageSize, string? searchTerms) =>
        BaseUrl + 
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}" +
            $"&searchTerms={searchTerms}";

    public static string GetById(Guid userId) =>
        BaseUrl + $"/{userId}";

    public static string SignUp => BaseUrl;
}