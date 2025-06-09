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
    public class ProduktService : BaseService, IProduktService
    {
        public ProduktService(FormaContext context) : base(context)
        {
        }

        public async Task<Produkt> ProduktFirst(int id)
        {
            var modelProdukt = await _context.Produkt
                .FirstOrDefaultAsync(p => p.IdProdukt == id);
            return modelProdukt;
        }

        public async Task<IList<Produkt>> ProduktToList()
        {
            var modelProdukt = await _context.Produkt
            .OrderBy(n => n.IdProdukt).ToListAsync();
            return modelProdukt;
        }
    }
}
