using ECommerce.Domain.Exceptions;
using System.Text.Json;

namespace ECommerce.Api.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DomainException ex)
        {
            _logger.LogWarning(ex, "Domain exception: {Message}", ex.Message);

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            var response = new
            {
                title = "Domain Error",
                status = StatusCodes.Status400BadRequest,
                detail = ex.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response, JsonSerializerOptions.Web));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new
            {
                title = "Internal Server Error",
                status = StatusCodes.Status500InternalServerError,
                detail = "Ocorreu um erro inesperado. Tente novamente mais tarde."
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response, JsonSerializerOptions.Web));
        }
    }
}
