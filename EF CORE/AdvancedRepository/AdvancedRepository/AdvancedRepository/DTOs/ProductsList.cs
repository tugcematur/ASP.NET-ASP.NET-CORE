using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.DTOs
{
    public class ProductsList
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string  CompanyName { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }

        public string ProductImage { get; set; }
    }
}
