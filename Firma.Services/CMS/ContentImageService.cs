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
    public class ContentImageService : BaseService, IContentImageService
    {
        public ContentImageService(FormaContext context) : base(context)
        {
        }

        public async Task<ContentImage> CheckKeyImageFirst(string key)
        {
            var modelImage = await _context.ContentImage
            .FirstOrDefaultAsync(c => c.Key == key);
            return modelImage;
        }

        public async Task<IList<ContentImage>> CheckKeyImageToList(string key)
        {
            var modelImage = await _context.ContentImage
            .Where(c => c.Key == key)
            .ToListAsync();
            return modelImage;
        }
    }
}
