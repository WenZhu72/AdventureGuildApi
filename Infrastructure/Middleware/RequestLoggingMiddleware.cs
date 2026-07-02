using System.Diagnostics;

namespace AdventureGuildApi.Infrastructure.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _Logger;

        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> Logger)
        {
            _next = next;
            _Logger = Logger;
        }

        public async Task InvokeAsync (HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            _Logger.LogInformation(
                "Incoming request {Method} {Path}",
                context.Request.Method,
                context.Request.Path);

            await _next(context);

            stopwatch.Stop();

            _Logger.LogInformation(
                "Completed request {Method} {Path} with status {StatusCode} in {ElapsedMilliseconds}ms",
                context.Request.Method,
                context.Request.Path,
                context.Response.StatusCode,
                stopwatch.ElapsedMilliseconds);
        }
    }
}
