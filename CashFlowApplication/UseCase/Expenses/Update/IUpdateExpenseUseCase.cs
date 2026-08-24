using CashFlow.Communication.Requests;
using CashFlow.Domain.Entity;

namespace CashFlow.Application.UseCase.Expenses.Update;

public interface IUpdateExpenseUseCase
{
    Task Execute(long id, RequestExpense requestExpense);

    void Valiate(RequestExpense expense);
}
