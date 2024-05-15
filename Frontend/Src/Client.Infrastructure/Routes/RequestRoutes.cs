namespace Client.Infrastructure.Routes;

public static class RequestRoutes
{
    private const string BaseUrl = "api/request";
    
    public static string GetPaginatedRequests(
        int pageNumber, int pageSize, string? searchTerms) =>
        BaseUrl +
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}" +
            $"&searchTerms={searchTerms}";

    public static string GetPaginatedRequestsByUserId(
        Guid userId, int pageNumber, int pageSize, string? searchTerms) =>
        BaseUrl + $"/user/{userId}" +
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}" +
            $"&searchTerms={searchTerms}";

    public static string GetById(Guid requestId) =>
        BaseUrl + $"/{requestId}";

    public static string Create => BaseUrl;

    public static string Update(Guid requestId) => 
        BaseUrl + $"/{requestId}";

    public static string Delete(Guid requestId) =>
        BaseUrl + $"/{requestId}";

    public static string ChangeStatus(Guid requestId) =>
        BaseUrl + $"/{requestId}/change-status";

}