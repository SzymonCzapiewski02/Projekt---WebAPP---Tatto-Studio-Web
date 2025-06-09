using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaData.Data.CMS
{
    public class Galeria
    {
        [Key]
        public int IdGaleria { get; set; }
        [ForeignKey("TattoArtists")]
        public int IdTattoArtists { get; set; }
        public TattoArtists? TattoArtists { get; set; }
        [Display(Name = "Url Zdjecia")]
        public string? UrlZdjecia { get; set; }
    }
}
