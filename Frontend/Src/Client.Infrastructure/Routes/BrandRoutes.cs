namespace Client.Infrastructure.Routes;

public static class BrandRoutes
{
    private const string BaseUrl = "api/car/brand";
    
    public static string GetAll => BaseUrl;
    
    public static string GetById(int brandId) => 
        BaseUrl + $"/{brandId}";

    public static string Create => BaseUrl;

    public static string Update(int brandId) =>
        BaseUrl + $"/{brandId}";

    public static string Delete(int brandId) =>
        BaseUrl + $"/{brandId}";
}