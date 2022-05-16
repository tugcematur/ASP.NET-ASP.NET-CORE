using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Interfaces
{ // Supplier ve Customer kapsayan bir class oluşturduk
    public  interface IEnterprise
    {
        public  string  CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string ContactName { get; set; }

    }
}
