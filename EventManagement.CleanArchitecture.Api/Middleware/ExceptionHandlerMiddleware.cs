using EventManagement.CleanArchitecture.Application.Exceptions;
using System.Net;
using System.Text.Json;
namespace EventManagement.CleanArchitecture.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            string message = string.Empty;

            switch (exception)
            {
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    message = notFoundException.Message;
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    message = badRequestException.Message;
                    break;
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    message = JsonSerializer.Serialize(validationException.ValidationErrors);
                    break;
                case Exception:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    message = "An error occured, please try again later !";
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            _logger.LogError(exception, "An error occurred: {Message}, StatusCode: {StatusCode}", message, context.Response.StatusCode);

            await context.Response.WriteAsync(JsonSerializer.Serialize(message));
        }
    }
}
