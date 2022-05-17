using FirstCode.Models.Data.Classes;
using FirstCode.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCode.Models.ViewModels
{
    public class PersonelModel
    {
        public PersonelModel()   // Çoğul olduğu için new liyoruz
        {
            Personel = new Personel();
        }
        public Personel Personel { get; set; }
        public string Header { get; set; }
        public string BtnVal { get; set; }
        public string BtnClass{ get; set; }
        public List<CityDTO> CityList { get; set; }
       
    }
}
