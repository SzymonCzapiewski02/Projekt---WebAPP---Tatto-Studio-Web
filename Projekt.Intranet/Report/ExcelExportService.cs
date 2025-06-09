using FirmaData.Data.CMS;
using FirmaData.Data.Sklep;
using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;

namespace Projekt.Intranet.Report
{
    public class ExcelExportService
    {
        public byte[] GenerujKlientaExcel(List<Klient> klients)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Klienci");

            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Imię";
            worksheet.Cell(1, 3).Value = "Nazwisko";
            worksheet.Cell(1, 4).Value = "Telefon";
            worksheet.Cell(1, 5).Value = "Email";

            var headerRange = worksheet.Range(1, 1, 1, 5);
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

            for (int i = 0; i < klients.Count; i++)
            {
                var k = klients[i];
                worksheet.Cell(i + 2, 1).Value = k.IdKlient;
                worksheet.Cell(i + 2, 2).Value = k.Imie;
                worksheet.Cell(i + 2, 3).Value = k.Nazwisko;
                worksheet.Cell(i + 2, 4).Value = k.NumerTelefonu;
                worksheet.Cell(i + 2, 5).Value = k.Email;
            }
            worksheet.Columns(1, 5).AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
        public byte[] GenerujPracownikaExcel(List<TattoArtists> tattoArtists)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Pracownicy");

            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Imię";
            worksheet.Cell(1, 3).Value = "Nazwisko";
            worksheet.Cell(1, 4).Value = "Przydomek";
            worksheet.Cell(1, 5).Value = "Lata Doświatczenia";
            worksheet.Cell(1, 6).Value = "Specjalizacja";
            worksheet.Cell(1, 7).Value = "Opis";
            worksheet.Cell(1, 8).Value = "Numer Telefonu";
            worksheet.Cell(1, 9).Value = "Email";
            worksheet.Cell(1, 10).Value = "Numer konta";

            var headerRange = worksheet.Range(1, 1, 1, 10);
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

            for (int i = 0; i < tattoArtists.Count; i++)
            {
                var k = tattoArtists[i];
                worksheet.Cell(i + 2, 1).Value = k.IdTattoArtists;
                worksheet.Cell(i + 2, 2).Value = k.Imie;
                worksheet.Cell(i + 2, 3).Value = k.Nazwisko;
                worksheet.Cell(i + 2, 4).Value = k.Przydomek;
                worksheet.Cell(i + 2, 5).Value = k.LataDoswiatczenia;
                worksheet.Cell(i + 2, 6).Value = k.Specjalizacja;
                worksheet.Cell(i + 2, 7).Value = k.Opis;
                worksheet.Cell(i + 2, 8).Value = k.NumerTelefonu;
                worksheet.Cell(i + 2, 9).Value = k.Email;
                worksheet.Cell(i + 2, 10).Value = k.NumerKonta;
            }
            worksheet.Columns(1, 5).AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
        public byte[] GenerujProduktuExcel(List<Produkt> produkts)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Produkty");

            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Nazwa";
            worksheet.Cell(1, 3).Value = "Opis";
            worksheet.Cell(1, 4).Value = "Cena";
            worksheet.Cell(1, 5).Value = "FotoUrl";
            worksheet.Cell(1, 6).Value = "IloscMagazynowa";

            var headerRange = worksheet.Range(1, 1, 1, 6);
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

            for (int i = 0; i < produkts.Count; i++)
            {
                var k = produkts[i];
                worksheet.Cell(i + 2, 1).Value = k.IdProdukt;
                worksheet.Cell(i + 2, 2).Value = k.Nazwa;
                worksheet.Cell(i + 2, 3).Value = k.Opis;
                worksheet.Cell(i + 2, 4).Value = k.Cena;
                worksheet.Cell(i + 2, 5).Value = k.FotoUrl;
                worksheet.Cell(i + 2, 6).Value = k.IloscMagazynowa;
            }
            worksheet.Columns(1, 5).AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
