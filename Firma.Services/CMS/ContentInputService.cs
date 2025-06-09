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
    public class ContentInputService : BaseService, IContentInputService
    {
        public ContentInputService(FormaContext context) : base(context)
        {
        }

        public async Task<IList<ContentInput>> CheckKeyInputButtonToList(string keyPierszy, string keyDrugi)
        {
            var modelInput = await _context.ContentInput
                .Where(c => c.Key == keyPierszy || c.Key == keyDrugi)
                .ToListAsync();

            return modelInput;
        }

        public async Task<ContentInput> CheckKeyInputFirst(string key)
        {
            var modelInput = await _context.ContentInput
            .FirstOrDefaultAsync(c => c.Key == key);
            return modelInput;
        }

        public async Task<IList<ContentInput>> CheckKeyInputToList(string key)
        {
            var modelInput = await _context.ContentInput
            .Where(c => c.Key == key)
            .ToListAsync();
            return modelInput;
        }
    }
}
