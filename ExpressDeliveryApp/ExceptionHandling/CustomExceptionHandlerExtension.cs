namespace ExpressDeliveryApp.ExceptionHandling;

public static class CustomExceptionHandlerExtension
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}