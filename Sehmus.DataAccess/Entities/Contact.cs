using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sehmus.DataAccess.Entities
{
    public class Contact:BaseEntity
    {
        [Display(Name = "Adres")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Address { get; set; }
        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Phone { get; set; }
        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [EmailAddress]
        public string Mail { get; set; }
    }
}
