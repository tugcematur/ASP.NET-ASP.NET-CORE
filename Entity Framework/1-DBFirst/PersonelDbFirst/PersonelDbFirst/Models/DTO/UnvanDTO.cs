using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelDbFirst.Models.DTO
{
    public class UnvanDTO
    {                                                //Ulke.cs 'de Personel1 ve Personel2 bağlantılarının gelmesini istemediğimden UnvanDTO oluşturuyorum 
        public int UnvanId{ get; set; }
        public string UnvanAd { get; set; }
    }
}