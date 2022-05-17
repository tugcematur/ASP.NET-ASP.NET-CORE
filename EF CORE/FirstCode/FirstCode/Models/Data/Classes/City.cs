using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCode.Models.Data.Classes
{
    public class City
    { [Key]
        public int CityId { get; set; }
        [Required, StringLength(10, MinimumLength = 3)]
        [Display(Name ="Şehir Ad")]
       // [StringLength(60,MinimumLength = 3)]
        public string CityName  { get; set; }

        public string Picture { get; set; }

        public  ICollection<Personel> Personels { get; set; }

    }
}
