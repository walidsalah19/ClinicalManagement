﻿using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalManagement.Extentions
{
    public static class ControllerExtensions
    {
        public static IActionResult HandleResult<T>(this ControllerBase controller, Result<T> result)
        {
            if (result == null)
                return controller.NotFound();

            if (!result.isSuccessed)
            {
                
                if (result.Error is Error err && Enum.TryParse<ErrorCodes>(err.code, out var errorCode))
                    {
                    return errorCode switch
                    {
                        ErrorCodes.BadRequest => controller.BadRequest(result),
                        ErrorCodes.NotFound => controller.NotFound(result),
                        ErrorCodes.AlreadyExists => controller.Conflict(result),
                        ErrorCodes.Unauthorized => controller.Unauthorized(result),
                        ErrorCodes.Forbidden => controller.StatusCode(StatusCodes.Status403Forbidden, result),
                        ErrorCodes.InternalServerError => controller.StatusCode(StatusCodes.Status500InternalServerError, result),
                        _ => controller.BadRequest(result)
                    };
                }

                return controller.BadRequest(result);
            }

            return controller.Ok(result);
        }
    }

}
