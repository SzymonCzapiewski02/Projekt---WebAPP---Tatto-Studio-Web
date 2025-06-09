using FirmaData.Data.CMS;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Projekt.Intranet.Report
{
    public class RezerwacjeRaport : IDocument
    {
        private readonly List<Rezerwacje> _rezerwacje;

        public RezerwacjeRaport(List<Rezerwacje> rezerwacje)
        {
            _rezerwacje = rezerwacje;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(50);
                page.Header().Text("Raport Rezerwacji").FontSize(20).Bold().AlignCenter();
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
                    });

                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Text("Id Tatto").Bold();
                        header.Cell().Element(CellStyle).Text("Klient").Bold();
                        header.Cell().Element(CellStyle).Text("Twórca").Bold();
                        header.Cell().Element(CellStyle).Text("Data").Bold();
                        header.Cell().Element(CellStyle).Text("Godzina").Bold();
                        header.Cell().Element(CellStyle).Text("Uwagi").Bold();
                    });

                    foreach (var item in _rezerwacje)
                    {
                        table.Cell().Element(CellStyle).Text(item.IdRezerwacja.ToString());
                        table.Cell().Element(CellStyle).Text(item.Klient.Imie + " " + item.Klient.Nazwisko);
                        table.Cell().Element(CellStyle).Text(item.TattoArtists.Przydomek);
                        table.Cell().Element(CellStyle).Text(item.Data.ToString("yyyy-MM-dd"));
                        table.Cell().Element(CellStyle).Text(item.Godzina.ToString(@"hh\:mm"));
                        table.Cell().Element(CellStyle).Text(item.Uwagi);
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
