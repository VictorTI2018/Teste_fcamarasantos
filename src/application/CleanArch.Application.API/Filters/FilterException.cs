using CleanArch.Core.Shared.Exceptions;
using CleanArch.Core.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CleanArch.Application.API.Filters
{
    public class FilterException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidatorException)
            {
                var errors = (ValidatorException)context.Exception;

                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                context.Result = new ObjectResult(new ValidatorMessage(errors.ErrorsMessage));
            } else if (context.Exception is InfraException)
            {
                var exception = context.Exception as InfraException;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new ObjectResult(new InfraMessage(exception.Message));
            }

            throw new NotImplementedException();
        }
    }
}
