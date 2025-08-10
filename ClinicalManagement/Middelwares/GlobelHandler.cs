﻿using ClinicalManagement.Application.Common.Result;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace ClinicalManagement.Middelwares
{
    public static class GlobelHandler
    {
        public static void ExceptionHandling(this IApplicationBuilder builder)
        {
            builder.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionFeature?.Error;

                    object response;
                    int statusCode;

                    if (exception is FluentValidation.ValidationException validationException)
                    {
                        statusCode = (int)HttpStatusCode.BadRequest;

                        var errors = validationException.Errors.Select(error => new Error
                        (
                            //Property = error.PropertyName,
                            message: error.ErrorMessage,
                            code : error.ErrorCode
                            //code: statusCode.ToString()
                        ));

                        response = Result<object>.Failure(errors);
                    }
                    else
                    {
                        statusCode = (int)HttpStatusCode.InternalServerError;

                        response = Result<Error>.Failure(new Error
                        (
                            message: exception?.Message,
                            // code=  exception?.StackTrace,
                            code: statusCode.ToString()

                        ));
                    }

                    context.Response.StatusCode = statusCode;

                    var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    await context.Response.WriteAsync(json);
                });
            });
        }
    }

}
