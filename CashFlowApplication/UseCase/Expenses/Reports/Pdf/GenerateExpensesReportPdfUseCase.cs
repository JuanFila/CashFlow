using CashFlow.Application.UseCase.Expenses.Reports.Pdf.Fonts;
using CashFlow.Domain.Repositories.Expenses;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Fonts;

namespace CashFlow.Application.UseCase.Expenses.Reports.Pdf;

public class GenerateExpensesReportPdfUseCase : IGenerateExpensesReportPdfUseCase
{
    private const string CURRENCY = "R$";
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

        var document = CreateDocument(month);
        var page = CreateSection(document);

        var table = page.AddTable();
        table.AddColumn("300");

        var row = table.AddRow();
        row.Cells[0].AddParagraph("Autor: Juan Fila");
        row.Cells[0].Format.Font = new Font { Name = FontHelper.RALEWAY_REGULAR, Size = 16 };
        row.Cells[0].VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
    
        var paragraph = page.AddParagraph();
        paragraph.Format.SpaceBefore = "40";
        paragraph.Format.SpaceAfter = "40";
        var title = string.Format("Total gasto em " + month.ToString("MMMM yyyy"));
        paragraph.AddFormattedText(title, new Font { Name = FontHelper.RALEWAY_REGULAR, Size = 15 });

        paragraph.AddLineBreak();

        var totalExpense = expenses.Sum(expenses => expenses.Amount);
        paragraph.AddFormattedText($"{totalExpense} {CURRENCY}", new Font { Name = FontHelper.WORKSANS_BOLD, Size = 50 });

        return RenderDocuments(document);
    }

    private Document CreateDocument(DateOnly month)
    {
        var document = new Document();
        document.Info.Title = $"Expenses Report - {month:MMMM yyyy}";
        document.Info.Author = "Juan Fila";

        var style = document.Styles["Normal"];
        style!.Font.Name = FontHelper.RALEWAY_REGULAR;

       
        return document;
    }

    private Section CreateSection(Document document)
    {
        var section = document.AddSection();
        
        section.PageSetup = document.DefaultPageSetup.Clone();
        section.PageSetup.PageFormat = PageFormat.A4;
        section.PageSetup.LeftMargin = 40;
        section.PageSetup.RightMargin = 40; 
        section.PageSetup.TopMargin = 80;
        section.PageSetup.BottomMargin = 80;


        return section;
    }
    
    private byte[] RenderDocuments(Document document)
    {
        var render = new PdfDocumentRenderer
        {
            Document = document
        };

        render.RenderDocument();

        using var file = new MemoryStream();

        render.PdfDocument.Save(file);

        return file.ToArray();
    }
}
