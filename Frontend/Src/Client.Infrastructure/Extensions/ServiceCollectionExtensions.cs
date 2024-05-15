using Client.Infrastructure.Handler;

namespace Client.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddManagers(this IServiceCollection services) =>
        services
            .AddTransient<IBrandManager, BrandManager>()
            .AddTransient<IModelManager, ModelManager>()
            .AddTransient<IRequestManager, RequestManager>()
            .AddTransient<IServiceTypeManager, ServiceTypeManager>()
            .AddTransient<ITokenManager, TokenManager>()
            .AddTransient<IUserManager, UserManager>();

    public static void AddServices(this IServiceCollection services) =>
        services
            .AddTransient<ITokenService, TokenService>();

    public static void AddAndConfigureHttpClientFactory(this IServiceCollection services) =>
        services
            .AddTransient<AuthorizationHeaderHandler>()
            .AddHttpClient(ApplicationConstants.BaseClientName)
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(ApplicationConstants.BaseAddress))
            .AddHttpMessageHandler<AuthorizationHeaderHandler>();
    
}