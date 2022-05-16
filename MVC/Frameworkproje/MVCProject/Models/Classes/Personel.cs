using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models.Classes
{
    public class Personel
    {
        public int PersonelId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public decimal Maas { get; set; }
        public int UnvanId { get; set; }
        public string UlkeId { get; set; }
        public string UyrukId { get; set; }
        public int YoneticiId { get; set; }

    }
}