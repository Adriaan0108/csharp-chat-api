using System.Net;
using System.Text.Json;
using csharp_chat_api.Common.Exceptions;

namespace csharp_chat_api.Infrastructure.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = error switch
            {
                BadRequestException => (int)HttpStatusCode.BadRequest,
                ForbiddenException => (int)HttpStatusCode.Forbidden,
                NotFoundException => (int)HttpStatusCode.NotFound,
                ServiceUnavailableException => (int)HttpStatusCode.ServiceUnavailable,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                UnprocessableEntityException => (int)HttpStatusCode.UnprocessableEntity,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var message = error.InnerException != null
                ? $"{error.Message} | Inner Exception: {error.InnerException.Message}"
                : error.Message;

            var result = JsonSerializer.Serialize(new { message });
            await context.Response.WriteAsync(result);
        }
    }
}