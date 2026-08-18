using CashFlow.Application.UseCase.Expenses.Reports.Pdf.Colors;
using CashFlow.Application.UseCase.Expenses.Reports.Pdf.Fonts;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Repositories.Expenses;
using DocumentFormat.OpenXml.Bibliography;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
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

        CreateHeader(page);

        var totalExpense = expenses.Sum(expenses => expenses.Amount);

        CreateTotalSpentSection(page, month, totalExpense);

        foreach (var expense in expenses)
        {
            var table = CreateExpenseTableSection(page);
            
            var row = table.AddRow();
            row.Height = 25;

            row.Cells[0].AddParagraph(expense.Title);
            row.Cells[0].Format.Font = new Font { Name = FontHelper.RALEWAY_BOLD, Size = 14, Color = ColorsHelper.BLACK };
            row.Cells[0].Shading.Color = ColorsHelper.RED_LIGHT;
            row.Cells[0].Shading.Color = ColorsHelper.RED_LIGHT;
            row.Cells[0].VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
            row.Cells[0].MergeRight = 2;
            row.Cells[0].Format.LeftIndent = 20;

            row.Cells[3].AddParagraph("Quantia");
            row.Cells[3].AddParagraph(expense.Title);
            row.Cells[3].Format.Font = new Font { Name = FontHelper.RALEWAY_BOLD, Size = 14, Color = ColorsHelper.WHITE };
            row.Cells[3].Shading.Color = ColorsHelper.RED_DARK;
            row.Cells[3].Shading.Color = ColorsHelper.RED_DARK;
            row.Cells[3].VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;

            row = table.AddRow();
            row.Height = 30;
            row.Borders.Visible = false;
        }

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
    
    private void CreateHeader(Section page)
    {
        var table = page.AddTable();
        table.AddColumn("300");

        var row = table.AddRow();
        row.Cells[0].AddParagraph("Autor: Juan Fila");
        row.Cells[0].Format.Font = new Font { Name = FontHelper.RALEWAY_REGULAR, Size = 16 };
        row.Cells[0].VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
    }

    private void CreateTotalSpentSection(Section page, DateOnly month, decimal totalExpense)
    {
        var paragraph = page.AddParagraph();
        paragraph.Format.SpaceBefore = "40";
        paragraph.Format.SpaceAfter = "40";
        var title = string.Format("Total gasto em " + month.ToString("MMMM yyyy"));
        paragraph.AddFormattedText(title, new Font { Name = FontHelper.RALEWAY_REGULAR, Size = 15 });

        paragraph.AddLineBreak();

        paragraph.AddFormattedText($"{totalExpense} {CURRENCY}", new Font { Name = FontHelper.WORKSANS_BOLD, Size = 50 });
    }

    private Table CreateExpenseTableSection(Section page)
    {
        var table = page.AddTable();

        table.AddColumn("195").Format.Alignment = ParagraphAlignment.Left;
        table.AddColumn("80").Format.Alignment = ParagraphAlignment.Center;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Right;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Right;

        return table;
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
