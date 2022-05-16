using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.DTOs
{
    public class EmployeesList
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string ManagerName { get; set; } // inner join ile yapılacak

        public decimal Salary { get; set; }



    }
}
