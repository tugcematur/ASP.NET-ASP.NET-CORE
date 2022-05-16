using MVCProject.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models.Views
{
    public class PersonelModel
    {
        public Personel Personel { get; set; }
        public string BtnVal { get; set; }
        public string BtnClass { get; set; }
        public string Baslik { get; set; }

        public string Type { get; set; }

        public string Label { get; set; }
    }
}