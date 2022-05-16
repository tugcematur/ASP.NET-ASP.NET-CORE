using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.DTOs
{
    public class FatDetailList
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }

        public string ProductImage { get; set; }


    }
}
