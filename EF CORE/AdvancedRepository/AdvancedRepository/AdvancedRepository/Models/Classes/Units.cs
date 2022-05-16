using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class Units:Base
    {
        public Units()
        {
            Products = new HashSet<Products>();
        }
        public string UnitName { get; set; }
        public ICollection<Products> Products { get; set; }

    }
}
