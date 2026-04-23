using CashFlow.Application.UseCase.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlowApplication.UseCase.Expenses.Register;
using Microsoft.AspNetCore.Mvc;
namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody] RequestExpense request,
        [FromServices] IRegisterExpensesUseCase useCase)
    {

        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
}