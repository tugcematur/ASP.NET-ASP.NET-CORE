using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{//Mal sattığımız kişi
    public class Customers:Enterprise
    {
        public Customers()
        {
            FatMasters = new HashSet<FatMaster>();
        }
        public int Rating { get; set; } // Hangi müşteri sınıfında olduğu


        public ICollection<FatMaster> FatMasters { get; set; }

    }
}
