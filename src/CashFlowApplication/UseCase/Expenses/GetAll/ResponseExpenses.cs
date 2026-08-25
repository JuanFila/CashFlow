using CashFlow.Communication.Response;

namespace CashFlow.Application.UseCase.Expenses.GetAll;

public class ResponseExpenses
{
    public List<ResponseShortExpense> Expenses { get; set; } = [];
}
