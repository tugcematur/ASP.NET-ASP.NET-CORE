using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{ //Malları tedarik etttiğimiz
    public class Suppliers:Enterprise
    {
        public Suppliers()
        {
            Products = new HashSet<Products>();
        }
        public bool Producer { get; set; }

        public ICollection<Products> Products { get; set; }

    }
}
