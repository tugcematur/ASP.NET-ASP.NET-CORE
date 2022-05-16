using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelDbFirst.Models.DTO
{
    public class PersonelDTO
    {
        public int Id { get; set; }
        public string  Ad{ get; set; }
        public string Soyad { get; set; }

        public string UnvanAd { get; set; }
        public string Ikamet { get; set; }
        public string Yonetici{ get; set; }
        public int UnvanId { get; set; }

        public decimal? Maas { get; set; }
        public string Uyruk { get; set; }


    }
}