using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sehmus.DataAccess.Entities
{
    public class Portfolio : BaseEntity
    {
        [Display(Name = "Resim1")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string ImageUrl1 { get; set; }
        [Display(Name = "Resim2")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string ImageUrl2 { get; set; }
        [Display(Name = "Resim3")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string ImageUrl3 { get; set; }
        [Display(Name = "Resim4")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string ImageUrl4 { get; set; }
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Category { get; set; }
        [Display(Name = "Müşteri")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Title { get; set; }
        [Display(Name = "Kullanılan Teknolojiler")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string TechnologiesUsed { get; set; }

        [Display(Name = "Proje Url Yolu")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string ProjectUrl { get; set; }
        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Description { get; set; }
    }
}
