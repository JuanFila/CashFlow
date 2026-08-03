namespace CashFlow.Application.UseCase.Expenses.Reports.Excel;

public interface IGenerateExpensesReporExcelUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
