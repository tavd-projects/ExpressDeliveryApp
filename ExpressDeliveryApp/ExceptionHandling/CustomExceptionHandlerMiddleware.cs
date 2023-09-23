using System.Net;
using System.Text.Json;
using ExpressDeliveryApp.Domain.Exceptions;

namespace ExpressDeliveryApp.ExceptionHandling;

public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;

        var message = new { Error = exception.Message };

        code = exception switch
        {
            ForbiddenException _ => HttpStatusCode.Forbidden,
            NotFoundException _ => HttpStatusCode.NotFound,
            TicketAlreadyCancelledException _ => HttpStatusCode.BadRequest,
            ArgumentException _ => HttpStatusCode.BadRequest,
            _ => code
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(JsonSerializer.Serialize(message));
    }
}