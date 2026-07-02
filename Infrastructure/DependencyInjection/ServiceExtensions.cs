using AdventureGuildApi.Services;

namespace AdventureGuildApi.Infrastructure.DependencyInjection;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<IAdventurerService, AdventurerService>();

        return services;
    }
}