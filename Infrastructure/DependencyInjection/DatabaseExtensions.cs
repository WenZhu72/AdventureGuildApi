using AdventureGuildApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AdventureGuildApi.Infrastructure.DependencyInjection;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' not found.");

        services.AddDbContext<AdventureGuildDbContext>(options =>
            options.UseSqlite(connectionString));

        return services;
    }
}