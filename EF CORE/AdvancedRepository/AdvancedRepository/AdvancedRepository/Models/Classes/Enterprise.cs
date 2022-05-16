using AdvancedRepository.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{ 
    abstract public class Enterprise : Base, IAdress, IEnterprise
    {
        public string Street { get; set; }
        public string Avenue { get; set; }
        public int CountyId { get; set; }
        //public int  CityId { get; set; }
        public int OutDoorNumber { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string ContactName { get; set; }
        public int PhoneNumber { get; set; }

        //public List<string> GetAdress()            Burada şuan tanımmlayamayız
        //{
        //    List<string> alist = new List<string>();
        //    alist.Add(Street);
        //    alist.Add(Avenue);
        //    alist.Add(OutDoorNumber.ToString());
        //    alist.Add($"{CountyId} - {CityId}");
        //    return alist;
        //}
        [ForeignKey("CountyId")]
        public Counties County { get; set; }
        public string GetTitle()
        {
            return $"Sn {CompanyName} Şirketi";
        }

    }


}

