using System.ComponentModel.DataAnnotations;

namespace Sehmus.DataAccess.Entities
{
    public class About: BaseEntity
    {
        [Display(Name = "Resim")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string ImageUrl { get; set; }
        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Description { get; set; }
        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Title { get; set; }
        [Display(Name = "Açıklama2")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Description2 { get; set; }
        [Display(Name = "Website")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Website { get; set; }
        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Mail { get; set; }
    }
}
