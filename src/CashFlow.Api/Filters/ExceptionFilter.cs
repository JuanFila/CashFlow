using CashFlow.Communication.Response;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is CashFlowException)
        {
            HandleProjetcException(context);
        }
        else
        {
            ThrowUnkowError(context);
        }
    }

    private void HandleProjetcException(ExceptionContext context)
    {
        if(context.Exception is ErrorOnValidationException)
        {
            var ex = (ErrorOnValidationException)context.Exception;

            var errorResponse = new ResponseError(ex.Errors);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            context.Result = new BadRequestObjectResult(errorResponse);
        }
        else
        {
            var errorResponse = new ResponseError(context.Exception.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }
    private void ThrowUnkowError(ExceptionContext context)
    {
        var errorResponse = new ResponseError(ResourceErroMessage.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;


            context.Result = new ObjectResult(errorResponse);
    }
}
