using System.ComponentModel.DataAnnotations;

namespace Sehmus.DataAccess.Entities
{
    public class Resume:BaseEntity
    {
        [Display(Name = "Başlık1")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Title1 { get; set; }
        [Display(Name = "Başlık2")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Title2 { get; set; }
        [Display(Name = "Zaman Aralığı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Date { get; set; }
        [Display(Name = "Açıklama1")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Description1 { get; set; }
        [Display(Name = "Açıklama2")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Description2 { get; set; }
    }
}
