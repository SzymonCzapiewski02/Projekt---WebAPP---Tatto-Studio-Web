using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaData.Data.CMS
{
    public class Tatto
    {
        [Key]
        public int IdTattoo { get; set; }

        [ForeignKey("Klient")]
        public int IdKlient { get; set; }
        public Klient? Klient { get; set; }

        [ForeignKey("TattoArtists")]
        public int IdTattoArtists { get; set; }
        public TattoArtists? TattoArtists { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Styl")]
        public string? Styl { get; set; }

        [Display(Name = "Foto URL")]
        [Column(TypeName = "nvarchar(max)")]
        public required string FotoURL { get; set; }

        [Required]
        [Display(Name = "Data wykonania")]
        public DateTime Data { get; set; }

        [Display(Name = "Cena")]
        public decimal? Cena { get; set; }
    }
}
