using AdventureGuildApi.Dtos;
using AdventureGuildApi.Infrastructure.Filters;
using AdventureGuildApi.Validators;

namespace AdventureGuildApi.Infrastructure.DependencyInjection
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddValidationServices(
            this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateAdventurerDto>,
                CreateAdventurerDtoValidator>();

            services.AddScoped<IValidator<UpdateAdventurerDto>,
                UpdateAdventurerDtoValidator>();

            services.AddScoped(typeof(ValidationFilter<>));

            return services;
        }
    }
}
