﻿using ApiMvc.Controllers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiMvc.Controllers.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsModelState = context.ModelState
                    .Where(x => x.Value?.Errors.Count() > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage))
                    .ToList();
                
                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.Message = "Ingrese todos los campos requeridos";
                errorResponse.Errors = new List<ErrorValidationModel>();

                errorsModelState.ForEach(error =>
                {
                    if (error.Value != null) 
                    {
                        foreach (var message in error.Value)
                        {
                            errorResponse.Errors.Add(new()
                            {
                                FieldName = error.Key,
                                Message = message
                            });
                        }
                    }
                    
                });

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }
            await next();
        }
    }
}
