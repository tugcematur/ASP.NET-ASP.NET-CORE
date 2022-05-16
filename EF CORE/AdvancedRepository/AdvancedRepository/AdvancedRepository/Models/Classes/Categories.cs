using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class Categories :Base
    {
        
        public Categories()
        {
           Products = new HashSet<Products>(); // Hızlı çalışacak
        }
        public string CategoryName{ get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
