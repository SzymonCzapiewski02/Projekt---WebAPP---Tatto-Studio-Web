using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaData.Data.CMS
{
    public class Strona
    {
        [Key]
        public int IdStrony { get; set; }
        [Required(ErrorMessage = "Tytuł odnościnka jest wymagany")]
        [MaxLength(10, ErrorMessage = "Link możę zawierać max 10 znaków")]
        [Display(Name = "Tytuł odnoścnika")]
        public required string LinkTytul { get; set; }
        [Required(ErrorMessage = "Tytuł strony jest wymagany")]
        [MaxLength(50, ErrorMessage = "tytuł zawierać max 10 znaków")]
        [Display(Name = "Tytuł strony")]
        public required string Tytul { get; set; }
        [Display(Name = "Pod Tytul")]
        [Column(TypeName = "nvarchar(max)")]
        public required string PodTytul { get; set; }
        [Display(Name = "Foto URL")]
        [Column(TypeName = "nvarchar(max)")]
        public required string FotoURL { get; set; }
        [Display(Name = "Pozycja wyswietlania")]
        [Required(ErrorMessage = "Wpisz pozycje wyswietlania")]
        public int Pozycja { get; set; }
        [Display(Name = "Pozycja Icon")]
        [Required(ErrorMessage = "Wpisz pozycje Icon")]
        [Column(TypeName = "nvarchar(max)")]
        public string Icon { get; set; }

    }
}
