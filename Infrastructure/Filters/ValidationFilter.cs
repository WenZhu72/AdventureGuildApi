using AdventureGuildApi.Validators;

using Microsoft.AspNetCore.Http;

namespace AdventureGuildApi.Infrastructure.Filters
{
    public class ValidationFilter<T> : IEndpointFilter
    {
        private readonly IValidator<T> _validator;

        public ValidationFilter(IValidator<T> validator)
        {
            _validator = validator;
        }

        public async ValueTask<object?> InvokeAsync(
            EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            T? dto = context.Arguments
                .OfType<T>()
                .FirstOrDefault();

            if (dto is null)
            {
                return Results.BadRequest(new
                {
                    Errors = new[] { "Request body is missing or inavlid" }
                });
            }

            List<string> validationErrors = _validator.Validate(dto);

            if (validationErrors.Any())
            {
                return Results.BadRequest(new
                {
                    Errors = validationErrors
                });
            }

            return await next(context);

        }
    }
}

