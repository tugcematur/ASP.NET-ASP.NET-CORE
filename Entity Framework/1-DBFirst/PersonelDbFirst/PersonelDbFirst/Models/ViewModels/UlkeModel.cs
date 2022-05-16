using PersonelDbFirst.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelDbFirst.Models.ViewModels
{
    public class UlkeModel
    {
        public Ulke Ulke { get; set; }
        public string Baslik { get; set; }
        public string BtnVal { get; set; }
        public string BtnClass { get; set; }
        public string InputType { get; set; }

    }
}