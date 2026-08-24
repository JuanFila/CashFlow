namespace CashFlow.Application.UseCase.Expenses.GetById;

public interface IExpenseByIdUseCase
{
    Task<ResponseExpensesById> Execute(long id);
}
