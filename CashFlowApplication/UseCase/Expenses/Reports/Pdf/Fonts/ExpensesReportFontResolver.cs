using PdfSharp.Charting;
using PdfSharp.Fonts;

namespace CashFlow.Application.UseCase.Expenses.Reports.Pdf.Fonts;

public class ExpensesReportFontResolver : IFontResolver
{
    public byte[]? GetFont(string faceName)
    {
        return null;
    }

    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {   
        new Font
        {
            Name = FontHelper.RALEWAY_BOLD
        };

        return new FontResolverInfo(familyName);
    }

  
}
        