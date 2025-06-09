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
    public class StronaService : BaseService, IStronaService
    {
        public StronaService(FormaContext context) 
            : base(context)
        {
        }

        public async Task<Strona> GetStronaImage(string stronaLink)
        {
            var modelImage = await _context.Strona.FirstOrDefaultAsync(s => s.LinkTytul == stronaLink);
            return modelImage;
        }

        public async Task<IList<Strona>> GetStronaPozycja()
        {
            var modelStrony = await _context.Strona
                .OrderBy(s => s.Pozycja)
                .ToListAsync();
            return modelStrony;
        }
    }
}
