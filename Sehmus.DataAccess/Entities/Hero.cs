using System.ComponentModel.DataAnnotations;

namespace Sehmus.DataAccess.Entities
{
    public class Hero:BaseEntity
    {
        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Title { get; set; }
        [Display(Name = "Uzmanlık Öğe")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Expert { get; set; }


    }
}
