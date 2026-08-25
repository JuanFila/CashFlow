using CashFlow.Communication.Response;

namespace CashFlow.Application.UseCase.Expenses.GetById;

public class ResponseExpensesById
{
    public List<ResponseShortExpense> Expenses { get; set; } = [];
}
