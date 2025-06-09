using Firma.Interfaces.Sklep;
using Firma.Services.Abstrakcja;
using FirmaData.Data;
using FirmaData.Data.Sklep;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Services.Sklep
{
    public class ZamowieniaService : BaseService, IZamowieniaService
    {
        public ZamowieniaService(FormaContext context) : base(context)
        {
        }

        public async Task<decimal> KoszykCena()
        {
            var modelKoszyk = await _context.Zamowienia
            .SumAsync(z => z.Produkt.Cena);
            return modelKoszyk;
        }

        public async Task<IList<Zamowienia>> KoszykToList()
        {
            var modelKoszyk = await _context.Zamowienia
            .Include(z => z.Produkt)
            .Include(z => z.Klient)
            .OrderBy(n => n.IdZamowienia).ToListAsync();
            return modelKoszyk;
        }
    }
}
