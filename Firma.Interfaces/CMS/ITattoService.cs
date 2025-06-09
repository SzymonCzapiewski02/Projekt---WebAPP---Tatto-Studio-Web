using FirmaData.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Interfaces.CMS
{
    public interface ITattoService
    {
        Task<IList<Tatto>> TattoToList(int ilePobrac);
    }
}
