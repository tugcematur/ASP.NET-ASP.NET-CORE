using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.ViewModels
{
    public class EmployeesModel
    {
        public Employees Employees { get; set; }
        public string Header { get; set; }

        public string BtnVal { get; set; }
        public string BtnClass { get; set; }
      

        public List<ManagersList> Managers { get; set; }
        public List <CountiesList> Counties { get; set; }

    }
}
