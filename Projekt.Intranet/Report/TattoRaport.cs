using FirmaData.Data.CMS;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Projekt.Intranet.Report
{
    public class TattoRaport : IDocument
    {
        private readonly List<Tatto> _tatto;

        public TattoRaport(List<Tatto> tatto)
        {
            _tatto = tatto;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(50);
                page.Header().Text("Raport Tatto").FontSize(20).Bold().AlignCenter();
                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(3);
                        columns.RelativeColumn(3);
                        columns.RelativeColumn(3);
                        columns.RelativeColumn(3);
                        columns.RelativeColumn(3);
                        columns.RelativeColumn(3);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Text("Id Tatto").Bold();
                        header.Cell().Element(CellStyle).Text("Klient").Bold();
                        header.Cell().Element(CellStyle).Text("Twórca").Bold();
                        header.Cell().Element(CellStyle).Text("Styl").Bold();
                        header.Cell().Element(CellStyle).Text("Foto URL").Bold();
                        header.Cell().Element(CellStyle).Text("Data wykonania").Bold();
                        header.Cell().Element(CellStyle).Text("Cena").Bold();
                    });

                    foreach (var item in _tatto)
                    {
                        table.Cell().Element(CellStyle).Text(item.IdTattoo.ToString());
                        table.Cell().Element(CellStyle).Text(item.Klient.Imie + " " + item.Klient.Nazwisko);
                        table.Cell().Element(CellStyle).Text(item.TattoArtists.Przydomek);
                        table.Cell().Element(CellStyle).Text(item.Styl);
                        table.Cell().Element(CellStyle).Text(item.FotoURL);
                        table.Cell().Element(CellStyle).Text(item.Data.ToString("yyyy-MM-dd"));
                        table.Cell().Element(CellStyle).Text($"{item.Cena:C}");
                    }

                    IContainer CellStyle(IContainer container)
                    {
                        return container
                            .Border(1)
                            .BorderColor(Colors.Grey.Darken2)
                            .Padding(5);
                    }
                });
                page.Footer().Text($"Data wygenerowania: {DateTime.Now.ToShortDateString()}").AlignCenter();
            });
        }
    }
}
