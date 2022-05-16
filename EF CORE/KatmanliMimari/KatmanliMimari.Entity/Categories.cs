using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari.Entity
{
    public class Categories :Base
    {
        public string ?CategoryName { get; set; }  // null olabilir uyarusu veriyor core 6 da çözüm için başına ? koyarsak null olabilir anlamına gelir
        public ICollection<Products> ?Products { get; set; }
    }
}
