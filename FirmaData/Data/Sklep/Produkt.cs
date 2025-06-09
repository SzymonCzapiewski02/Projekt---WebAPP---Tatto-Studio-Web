using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaData.Data.Sklep
{
    public class Produkt
    {
        [Key]
        public int IdProdukt { get; set; }
        [Required(ErrorMessage = "Wpisz nazwe produktu")]
        [MaxLength(100)]
        [Display(Name = "Nazwa")]
        public required string Nazwa { get; set; }
        [Required(ErrorMessage = "Wpisz opis produktu")]
        [MaxLength(300)]
        [Display(Name = "Opis")]
        public required string Opis { get; set; }
        [Required(ErrorMessage = "Wpisz cene produktu")]
        [Display(Name = "Cena")]
        public decimal Cena { get; set; }
        [Display(Name = "Foto")]
        public string? FotoUrl { get; set; } = string.Empty;
        [Display(Name = "Stan magazynowy")]
        public int IloscMagazynowa { get; set; }
        public ICollection<Zamowienia> Zamowienia { get; set; } = new List<Zamowienia>();
    }
}
