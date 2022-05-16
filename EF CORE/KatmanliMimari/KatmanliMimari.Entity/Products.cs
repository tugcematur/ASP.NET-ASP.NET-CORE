using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari.Entity
{
    public  class Products : Base

    {
        public string ?ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Categories ?Categories { get; set; }

    }
}
