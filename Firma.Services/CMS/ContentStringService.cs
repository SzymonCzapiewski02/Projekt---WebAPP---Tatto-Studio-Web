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
    public class ContentStringService : BaseService, IContentStringService
    {
        public ContentStringService(FormaContext context) : base(context)
        {
        }

        public async Task<IList<ContentString>> CheckKeyStringDwaToList(string keyPierszy, string keyDrugi)
        {
            var modelString = await _context.ContentString
            .Where(c => c.Key == keyPierszy || c.Key == keyDrugi)
            .ToListAsync();
            return modelString;
        }

        public async Task<ContentString> CheckKeyStringFirst(string key)
        {
            var modelString = await _context.ContentString
            .FirstOrDefaultAsync(c => c.Key == key);
            return modelString;
        }

        public async Task<IList<ContentString>> CheckKeyStringToList(string key)
        {
            var modelString = await _context.ContentString
            .Where(c => c.Key == key)
            .ToListAsync();
            return modelString;
        }
    }
}
