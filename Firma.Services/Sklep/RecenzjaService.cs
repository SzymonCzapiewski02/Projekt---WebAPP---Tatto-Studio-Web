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
    public class RecenzjaService : BaseService, IRecenzjaService
    {
        public RecenzjaService(FormaContext context) : base(context)
        {
        }

        public async Task<IList<Recenzja>> RecenzjeToListTake(int ilePobrac)
        {
            var modelRecenzje = await _context.Recenzja
            .Include(r => r.Klient)
            .Include(r => r.TattoArtists)
            .OrderBy(n => n.IdRecenzji)
            .Take(ilePobrac).ToListAsync();
            return modelRecenzje;
        }
    }
}
