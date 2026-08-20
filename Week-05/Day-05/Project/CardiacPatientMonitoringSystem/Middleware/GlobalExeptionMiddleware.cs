using Microsoft.AspNetCore.Mvc;

namespace CardiacPatientMonitoringSystem.Middleware;
public class GlobalExeptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExeptionMiddleware> _logger;
    public GlobalExeptionMiddleware(RequestDelegate next, ILogger<GlobalExeptionMiddleware> logger)
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
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Unhandled exception occurred for request {Methode} {Path}",
                context.Request.Method,
                      context.Request.Path
            );
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/problem+json";

            var problemDetails = new ProblemDetails
            {
                Title = "An unexpected error occurred.",
                Status = StatusCodes.Status500InternalServerError
            };

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}