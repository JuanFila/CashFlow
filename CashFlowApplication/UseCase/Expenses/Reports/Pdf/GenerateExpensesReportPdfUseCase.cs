using CashFlow.Application.UseCase.Expenses.Reports.Pdf.Fonts;
using CashFlow.Domain.Repositories.Expenses;
using PdfSharp.Fonts;

namespace CashFlow.Application.UseCase.Expenses.Reports.Pdf;

public class GenerateExpensesReportPdfUseCase : IGenerateExpensesReportPdfUseCase
{
    private const string CURRENCY = "USD";
    private readonly IExpenseReadOnlyRepository _repository;

    public GenerateExpensesReportPdfUseCase(IExpenseReadOnlyRepository repository)
    {
        _repository = repository;

        GlobalFontSettings.FontResolver = new ExpensesReportFontResolver();
    }

    public async Task<byte[]> ExecuteAsync(DateOnly month)
    {
        var expenses = await _repository.GetByMonth(month);
        if(expenses.Count == 0) 
        {
            return [];        
        }
        return [];
    }
}
