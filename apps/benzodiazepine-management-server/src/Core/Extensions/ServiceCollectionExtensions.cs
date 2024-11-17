using BenzodiazepineManagement.APIs;

namespace BenzodiazepineManagement;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBenzodiazepinesService, BenzodiazepinesService>();
        services.AddScoped<IImageResourcesService, ImageResourcesService>();
        services.AddScoped<IPharmacologicalPropertiesService, PharmacologicalPropertiesService>();
        services.AddScoped<IUserActionsService, UserActionsService>();
    }
}
