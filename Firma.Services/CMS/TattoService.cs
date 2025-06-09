using Firma.Interfaces.CMS;
using Firma.Services.Abstrakcja;
using FirmaData.Data;
using FirmaData.Data.CMS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Services.CMS
{
    public class TattoService : BaseService, ITattoService
    {
        public TattoService(FormaContext context) : base(context)
        {
        }

        public async Task<IList<Tatto>> TattoToList(int ilePobrac)
        {
            var modelTatto = await _context.Tatto
            .Include(r => r.Klient)
            .Include(r => r.TattoArtists)
            .OrderByDescending(n => n.Data)
            .ThenBy(n => n.IdTattoo)
            .Take(ilePobrac).ToListAsync();
            return modelTatto;
        }
    }
}
