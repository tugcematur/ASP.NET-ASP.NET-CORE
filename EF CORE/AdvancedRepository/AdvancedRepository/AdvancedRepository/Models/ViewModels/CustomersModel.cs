using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.ViewModels
{
    public class CustomersModel
    {

        public Customers Customers { get; set; }
        public string Header { get; set; }

        public string BtnVal { get; set; }
        public string BtnClass { get; set; }
        public List<CountiesList> Counties { get; set; }
        public List<CitiesList> Cities{ get; set; }
    }
}
