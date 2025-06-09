using FirmaData.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Interfaces.CMS
{
    public interface IContentImageService
    {
        Task<IList<ContentImage>> CheckKeyImageToList(string key);
        Task<ContentImage> CheckKeyImageFirst(string key);
    }
}
