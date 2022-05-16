using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.ViewModels
{
    public class FatDetailModel
    {
        public FatDetailModel()
        {
            FatMaster = new FatMaster();
            FatDetail = new FatDetail();
        }

       
        public FatMaster FatMaster { get; set; }

        public FatDetail FatDetail { get; set; }
        public List<ProductsSelect> Products { get; set; }

        public List<CustomerSelect> Customers { get; set; }

        public IQueryable<FatDetailList> FatDetailList { get; set; }

        public string Total { get; set; }

       

    }
}
