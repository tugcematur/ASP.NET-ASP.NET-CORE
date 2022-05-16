using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepository.Models.Classes
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }

        public ICollection<Personel> Personels;
    }
}
