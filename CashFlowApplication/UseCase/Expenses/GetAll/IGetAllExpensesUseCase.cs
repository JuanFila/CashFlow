namespace CashFlow.Application.UseCase.Expenses.GetAll;

public interface IGetAllExpensesUseCase
{
    Task<ResponseExpenses> Execute();
}
