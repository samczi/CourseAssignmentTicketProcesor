using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;
using System.IO;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
using System.Text;
using Tickets_data_aggregator;
using static UglyToad.PdfPig.Core.PdfSubpath;

var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
var filed = Path.Combine(projectFolder, @"Tickets");
string[] files = Directory.GetFiles(filed);
foreach (string file in files)
{
    var ticketProcessor = new TicketProcesor();
    using (PdfDocument document = PdfDocument.Open($"{file}"))
    {
        foreach (Page page in document.GetPages())
        {
            var text = ContentOrderTextExtractor.GetText(page, true);
            string[] splitText = text.Split(Environment.NewLine);
            ticketProcessor.ProcessText(splitText);
            foreach (string s in ticketProcessor.output)
            {
                Console.WriteLine(s);
            }   

        }
    }
}
Console.ReadKey();