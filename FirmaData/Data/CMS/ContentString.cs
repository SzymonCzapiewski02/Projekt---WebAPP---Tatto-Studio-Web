using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaData.Data.CMS
{
    public class ContentString
    {
        [Key]
        public int IdContentString { get; set; }
        [Display(Name = "Klucz")]
        public string Key { get; set; } = string.Empty;
        [Display(Name = "Wartość")]
        public string Value { get; set; } = string.Empty;
    }
}
