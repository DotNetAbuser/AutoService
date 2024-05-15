namespace Client.Infrastructure.Routes;

public static class ServiceTypeRoutes
{
    private const string BaseUrl = "api/car/service_type";
    
    public static string GetAll => BaseUrl;

    public static string GetById(int serviceTypeId) =>
        BaseUrl + $"/{serviceTypeId}";

    public static string Create => BaseUrl;
    
    public static string Update(int serviceTypeId) => 
        BaseUrl + $"/{serviceTypeId}";

    public static string Delete(int serviceTypeId) =>
        BaseUrl + $"/{serviceTypeId}";
}