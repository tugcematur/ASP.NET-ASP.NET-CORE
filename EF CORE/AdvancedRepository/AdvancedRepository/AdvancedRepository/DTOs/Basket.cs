using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.DTOs
{
    public class Basket
    {
        public int Id { get; set; }
        public string  ProductName { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
