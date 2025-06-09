using FirmaData.Data.Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Interfaces.Sklep
{
    public interface IRecenzjaService
    {
        Task<IList<Recenzja>> RecenzjeToListTake(int ilePobrac);
    }
}
