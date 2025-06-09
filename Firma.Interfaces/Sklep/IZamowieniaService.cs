using FirmaData.Data.Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Interfaces.Sklep
{
    public interface IZamowieniaService
    {
        Task<IList<Zamowienia>> KoszykToList();
        Task<decimal> KoszykCena();
    }
}
