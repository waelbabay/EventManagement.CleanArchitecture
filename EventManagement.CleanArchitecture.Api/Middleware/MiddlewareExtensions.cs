namespace EventManagement.CleanArchitecture.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlerMiddleware>();
        }

        public static IApplicationBuilder UseCustomCorrelationId(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CorrelationIdMiddleware>();
        }
    }
}
