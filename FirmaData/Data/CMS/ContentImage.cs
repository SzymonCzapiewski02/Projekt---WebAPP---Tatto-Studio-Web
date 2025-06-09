using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaData.Data.CMS
{
    public class ContentImage
    {
        [Key]
        public int IdContentImage { get; set; }
        [Display(Name = "Klucz")]
        public string Key { get; set; } = string.Empty;
        [Display(Name = "Obrazek")]
        public string Image { get; set; } = string.Empty;
    }
}
