using AdventureGuildApi.Infrastructure.ExceptionHandling;

namespace AdventureGuildApi.Infrastructure.DependencyInjection
{
    public static class ExceptionExtensions
    {
        public static IServiceCollection AddExceptionHandling(
            this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();

            services.AddProblemDetails();

            return services;
        }
    }
}
