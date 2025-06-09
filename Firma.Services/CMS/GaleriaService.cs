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
    public class GaleriaService : BaseService, IGaleriaService
    {
        public GaleriaService(FormaContext context) : base(context)
        {
        }

        public async Task<IList<Galeria>> GaleriaToList()
        {
            var modelGaleria = await _context.Galeria
            .Include(z => z.TattoArtists)
            .OrderBy(n => n.IdGaleria).ToListAsync();
            return modelGaleria;
        }
    }
}
