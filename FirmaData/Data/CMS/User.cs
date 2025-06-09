using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaData.Data.CMS
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Podaj login")]
        [MaxLength(50)]
        public required string Login { get; set; }
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Podaj Hasło")]
        [MaxLength(50)]
        public required string haslo { get; set; }
    }
}
