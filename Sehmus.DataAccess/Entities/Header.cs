using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sehmus.DataAccess.Entities
{
    public class Header:BaseEntity
    {
        public int Id { get; set; }
        [Display(Name = "Resim")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string ImageUrl { get; set; }
        [Display(Name = "Ad ve Soyad")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string FullName { get; set; }

        [Display(Name = "Youtube link")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Youtube { get; set; }

        [Display(Name = "İnstagram link")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string İnstagram { get; set; }

        [Display(Name = "Github link")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Github { get; set; }
        [Display(Name = "Linkedin link")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Linkedin { get; set; }
    }
}
