using Microsoft.Extensions.Primitives;

namespace EventManagement.CleanArchitecture.Api.Middleware
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private const string CorrelationIdHeaderName = "Correlation-Id";

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string? correlationId = GetCorrelationId(context);

            if(correlationId == null)
            {
                correlationId= Guid.NewGuid().ToString();
                context.Request.Headers.Append(CorrelationIdHeaderName, correlationId);
            }

            context.Response.Headers.Append(CorrelationIdHeaderName, correlationId);

            await _next(context);
        }

        private static string? GetCorrelationId(HttpContext context)
        {
            context.Request.Headers.TryGetValue(
                CorrelationIdHeaderName,
                out StringValues correlationId);

            return correlationId.FirstOrDefault();
        }
    }
}
