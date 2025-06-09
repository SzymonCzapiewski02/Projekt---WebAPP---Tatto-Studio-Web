using FirmaData.Data.Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Interfaces.Sklep
{
    public interface IProduktService
    {
        Task<IList<Produkt>> ProduktToList();
        Task<Produkt> ProduktFirst(int id);
    }
}
