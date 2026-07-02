using AdventureGuildApi.Dtos;
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

            return services;
        }
    }
}
