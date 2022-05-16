using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.DTOs
{
    public class CountiesList
    {
        public int Id { get; set; }
        public string CountyName { get; set; }
        public string CityName { get; set; }
        public int CityId { get; set; }
    }
}
