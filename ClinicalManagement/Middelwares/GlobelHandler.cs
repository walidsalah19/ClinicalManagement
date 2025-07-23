using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace ClinicalManagement.Middelwares
{
    public static class GlobelHandler
    {
        public static void ExceptionHandling(this IApplicationBuilder builder)
        {
            builder.UseExceptionHandler(o => o.Run(
                async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exceptions = errorFeature.Error;

                    if (!(exceptions is FluentValidation.ValidationException validationException))
                        throw exceptions;

                    var error = validationException.Errors.Select(error => new
                    {
                        Properity = error.PropertyName,
                        Message = error.ErrorMessage,
                        Code = error.ErrorCode,

                    });

                    var errorContent = JsonSerializer.Serialize(error);
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsync(errorContent);
                }

                ));
        }
    }

}
