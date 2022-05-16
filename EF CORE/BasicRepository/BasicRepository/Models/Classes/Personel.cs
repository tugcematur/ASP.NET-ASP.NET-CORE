using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepository.Models.Classes
{
    public class Personel
    {
     

        [Key]
        public int PersonelId { get; set; }
        public  string PersonelName { get; set; }
        public string PersonelSurname{ get; set; }

     
        [ForeignKey("CityId")]
        public int CityId { get; set; }
        public City City{ get; set; }

    }
}
