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

        var cashFlowException = context.Exception as CashFlowException;
        var errorResponse = new ResponseError(cashFlowException!.GetErrors());

        context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
        context.Result = new ObjectResult(new ResponseError(cashFlowException.Message));

    }
    private void ThrowUnkowError(ExceptionContext context)
    {   
        var errorResponse = new ResponseError(ResourceErroMessage.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Result = new ObjectResult(errorResponse);
    }
}
