using CashFlow.Communication.Requests;
using CashFlow.Communication.Response;

namespace CashFlow.Application.UseCase.Expenses.Register;

public interface IRegisterExpensesUseCase
{
    Task<ResponseRegisterExpenses> Execute(RequestExpense request);
}
