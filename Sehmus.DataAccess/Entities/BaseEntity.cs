using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sehmus.DataAccess.Entities
{
    public class BaseEntity
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Ekleyen kişi")]
        public int? AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
