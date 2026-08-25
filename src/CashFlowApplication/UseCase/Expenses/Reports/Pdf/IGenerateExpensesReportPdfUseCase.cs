namespace CashFlow.Application.UseCase.Expenses.Reports.Pdf;

public interface IGenerateExpensesReportPdfUseCase
{
    Task<byte[]> ExecuteAsync(DateOnly month);
}
