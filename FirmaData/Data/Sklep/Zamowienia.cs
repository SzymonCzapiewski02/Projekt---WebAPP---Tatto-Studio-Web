using FirmaData.Data.CMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaData.Data.Sklep
{
    public class Zamowienia
    {
        [Key]
        public int IdZamowienia { get; set; }
        [ForeignKey("Klient")]
        public int IdKlient { get; set; }
        public Klient? Klient { get; set; }
        [ForeignKey("Produkt")]
        public int IdProduktu { get; set; }
        public Produkt? Produkt { get; set; }
    }
}
