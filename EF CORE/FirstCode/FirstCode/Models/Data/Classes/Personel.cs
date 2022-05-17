using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCode.Models.Data.Classes
{
    public class Personel
    {   [Key]
        public int PersonelId { get; set; }
        [Required]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Soyad")]
        public  string Surname { get; set; }
        [Required]
        [Display(Name = "Şehir")]
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City  { get; set; }
       

    }
}
