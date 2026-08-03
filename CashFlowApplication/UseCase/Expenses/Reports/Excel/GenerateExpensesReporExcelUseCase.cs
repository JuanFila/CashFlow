using ClosedXML.Excel;

namespace CashFlow.Application.UseCase.Expenses.Reports.Excel;

public class GenerateExpensesReporExcelUseCase : IGenerateExpensesReporExcelUseCase
{
    public async Task<byte[]> Execute(DateOnly month)
    {
        var workbook = new XLWorkbook();

        workbook.Author = "CashFlow";
        workbook.Style.Font.FontSize = 12;
        workbook.Style.Font.FontName = "Times New Roman";
        
        var worksheet = workbook.Worksheets.Add(month.ToString("Y"));

        GenerateHeader(worksheet);

        var file = new MemoryStream();  
        workbook.SaveAs(file);
        return file.ToArray();
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
