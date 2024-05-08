namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddHelpers(this IServiceCollection services) =>
        services
            .AddTransient<IPasswordHasher, PasswordHasher>();


    public static void AddRepositories(this IServiceCollection services) =>
        services
            .AddTransient<IBrandRepository, BrandRepository>()
            .AddTransient<IModelRepository, ModelRepository>()
            .AddTransient<IRequestRepository, RequestRepository>()
            .AddTransient<IRoleRepository, RoleRepository>()
            .AddTransient<IServiceTypeRepository, ServiceTypeRepository>()
            .AddTransient<ISessionRepository, SessionRepository>()
            .AddTransient<IUserRepository, UserRepository>();

    public static void AddServices(this IServiceCollection services) =>
        services
            .AddTransient<IBrandService, BrandService>()
            .AddTransient<IModelService, ModelService>()
            .AddTransient<IRequestService, RequestService>()
            .AddTransient<IServiceTypeService, ServiceTypeService>()
            .AddTransient<ITokenService, TokenService>()
            .AddTransient<IUserService, UserService>();


}