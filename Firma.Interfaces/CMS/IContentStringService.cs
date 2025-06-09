using FirmaData.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Interfaces.CMS
{
    public interface IContentStringService
    {
        Task<IList<ContentString>> CheckKeyStringToList(string key);
        Task<ContentString> CheckKeyStringFirst(string key);
        Task<IList<ContentString>> CheckKeyStringDwaToList(string keyPierszy, string keyDrugi);

    }
}
