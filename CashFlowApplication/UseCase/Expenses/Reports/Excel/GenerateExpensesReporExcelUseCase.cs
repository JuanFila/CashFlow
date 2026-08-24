using CashFlow.Domain.Enums;
using CashFlow.Domain.Repositories.Expenses;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCase.Expenses.Reports.Excel;

public class GenerateExpensesReporExcelUseCase : IGenerateExpensesReporExcelUseCase
{
    private readonly IExpenseReadOnlyRepository _repository;

    public GenerateExpensesReporExcelUseCase(IExpenseReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<byte[]> Execute(DateOnly month)
    {

        var expenses = await _repository.GetByMonth(month);

        if(expenses.Count == 0)
        {
            return [];
        }

        using var workbook = new XLWorkbook();

        workbook.Author = "CashFlow";
        workbook.Style.Font.FontSize = 12;
        workbook.Style.Font.FontName = "Times New Roman";
        
        var worksheet = workbook.Worksheets.Add(month.ToString("Y"));

        GenerateHeader(worksheet);

        var raw = 2;
        foreach (var expense in expenses) 
        {
            worksheet.Cell($"A{raw}").Value = expense.Title;
            worksheet.Cell($"B{raw}").Value = expense.Date;
            worksheet.Cell($"C{raw}").Value = ConvertPaymentTypeToString(expense.PaymentType);
            worksheet.Cell($"D{raw}").Value = expense.Amount;
            worksheet.Cell($"E{raw}").Value = expense.Description;

            raw++;
        }

        worksheet.Columns().AdjustToContents();

        var file = new MemoryStream();  
        workbook.SaveAs(file);
        return file.ToArray();
    }

    private string ConvertPaymentTypeToString(PaymentType paymentType)
    {
     return paymentType switch
     {
         PaymentType.Cash => "Dinheiro",
         PaymentType.CreditCard => "Cartão de Crédito",
         PaymentType.DebitCard => "Cartão de Débito",
         PaymentType.EletronicTransfer => "Transferência Eletrônica",
         _ => string.Empty
     }; 
    }

    private void GenerateHeader(IXLWorksheet worksheet)
    {
        worksheet.Cell("A1").Value = "Title";
        worksheet.Cell("B1").Value = "Date";
        worksheet.Cell("C1").Value = "Payment type";
        worksheet.Cell("D1").Value = "Amount";
        worksheet.Cell("E1").Value = "Description";

        var headerRange = worksheet.Range("A1:E1");
        headerRange.Style.Font.Bold = true;
        headerRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#F5C2B6");
        headerRange.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

    }
}
