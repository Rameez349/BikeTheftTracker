using System.Text.Json;
using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BikeTheftTracker.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(exception =>
            {
                exception.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                    var response = ExceptionHandler.HandleException(exceptionHandlerPathFeature?.Error);

                    context.Response.StatusCode = response.StatusCode;
                    context.Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Json;

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
