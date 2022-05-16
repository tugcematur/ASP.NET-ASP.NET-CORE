using BasicRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepository.Models.ViewModel
{
    public class CityModel
    {
        public City City { get; set; }
        public string Header { get; set; }
        public  string BtnVal { get; set; }
        public string BtnClass { get; set; }
    }
}
