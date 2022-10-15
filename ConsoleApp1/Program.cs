using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

// code in your main method
var document = Document.Create(container =>
{
    container.Page(page =>
    {
        page.Content().Element(ComposeContent);


    });

});

document.GeneratePdf("hello.pdf");


document.ShowInPreviewer();












void ComposeContent(IContainer container)
{
   

        var pageSizes = new List<(string name, string width)>()
{
    ("Business number", "890878382"),
    ("Number of employees", "27"),
    ("Contact information" ,"Don HutchinsonPosition: Health and Safety Co-ordinatorPhone: 905 - 951 - 4010 Ext:Email: dhutchinson @boltonsteel.com"),
    ("Parent company","N/A"),
    ("Typical days of operation","mon/tue/wed/thu/fr"),
    ("Operating hours", "9"),
    ("Start time", "07:00"),
        ("Shutdown periods","N/A" ),
            ("Activities", "")


};

    const int inchesToPoints = 72;

    container
.Padding(10)



.Table(table =>
{
    IContainer DefaultCellStyle(IContainer container, string backgroundColor)
    {
        return container
            .Border(1)
            .BorderColor(Colors.White)
            .Background(backgroundColor)
            .PaddingVertical(5)
            .PaddingHorizontal(10)
            .AlignMiddle()
            .ShowOnce();
    }
    
    table.ColumnsDefinition(columns =>
    {
        columns.ConstantColumn(200);

        columns.ConstantColumn(175);
    });

    table.Header(header =>
    {
        header.Cell().ColumnSpan(2).BorderTop(4).BorderColor(Colors.Black);

    
    });

    foreach (var page in pageSizes)
    {
        table.Cell().Element(CellStyle).ExtendHorizontal().Text(page.name).Style(TextStyle.Default.SemiBold()).FontFamily("Times New Roman");

        // inches
        table.Cell().Element(CellStyle1).AlignLeft().Text(page.width).FontFamily("Times New Roman");
      
        table.Cell().ColumnSpan(2).BorderBottom(1).BorderColor(Colors.Black);

        IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten2);
        IContainer CellStyle1(IContainer container) => DefaultCellStyle(container, Colors.White);
     ;




    }

});
}