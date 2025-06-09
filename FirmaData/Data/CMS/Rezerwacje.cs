using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaData.Data.CMS
{
    public class Rezerwacje
    {
        [Key]
        public int IdRezerwacja { get; set; }

        [ForeignKey("Klient")]
        public int IdKlient { get; set; }
        public Klient? Klient { get; set; }

        [ForeignKey("TattoArtists")]
        public int IdTattoArtists { get; set; }
        public TattoArtists? TattoArtists { get; set; }

        [Required(ErrorMessage = "Data jest wymagana.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data Rezerwacji")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Podanie godziny jest wymagane.")]
        [Display(Name = "Godzina")]
        [DataType(DataType.Time)]
        public TimeSpan Godzina { get; set; }

        [MaxLength(400)]
        [Display(Name = "Uwagi")]
        public string? Uwagi { get; set; }

        public ICollection<Platnosc> Platnosc { get; set; } = new List<Platnosc>();
    }
}
