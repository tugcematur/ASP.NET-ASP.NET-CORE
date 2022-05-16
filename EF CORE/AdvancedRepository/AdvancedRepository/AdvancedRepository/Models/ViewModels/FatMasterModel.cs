using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.ViewModels
{
    public class FatMasterModel
    {
        public FatMasterModel()
        {
            FatMaster = new FatMaster();
        }
        public FatMaster FatMaster { get; set; }
        public List<CustomerSelect> Customers { get; set; }

        public string Head { get; set; }
        public string BtnVal { get; set; }
        public string BtnClass { get; set; }

    }
}
