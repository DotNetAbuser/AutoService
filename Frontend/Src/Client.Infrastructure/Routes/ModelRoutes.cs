namespace Client.Infrastructure.Routes;

public static class ModelRoutes
{
    private const string BaseUrl = "api/car/model";
    
    public static string GetAllModelsByBrandId(int brandId) =>
        BaseUrl + $"/brand/{brandId}";

    public static string GetById(int modelId) =>
        BaseUrl + $"/{modelId}";

    public static string Create => BaseUrl;

    public static string Update(int modelId) =>
        BaseUrl + $"/{modelId}";

    public static string Delete(int modelId) =>
        BaseUrl + $"/{modelId}";
}