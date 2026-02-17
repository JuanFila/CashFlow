using CashFlow.Communication.Requests;
using CashFlowApplication.UseCase.Expenses.Register;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestExpense request)
    {
        var useCase = new RegisterExpensesUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
}