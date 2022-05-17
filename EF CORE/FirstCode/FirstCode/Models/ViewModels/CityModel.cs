using FirstCode.Models.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCode.Models.ViewModels
{
    public class CityModel
    {
        //public CityModel()   // buna gerek yok  Tekil olduğu için   gelecekteki versiyonlar da bu değşebilir elbette...
        //{
        //    City = new City();
        //}
        public string Header { get; set; }
        public string BtnClass { get; set; }
        public string BtnVal { get; set; }
        public City City { get; set; }
    }
}
