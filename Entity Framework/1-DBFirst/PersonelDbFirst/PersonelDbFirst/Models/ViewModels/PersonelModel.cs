using PersonelDbFirst.Models.Data;
using PersonelDbFirst.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelDbFirst.Models.ViewModels
{
    public class PersonelModel
    {
        public Personel Personel { get; set; }
        public string BtnClass { get; set; }
        public string BtnVal { get; set; }
        public string Baslik { get; set; }
        public string InputType { get; set; }

        public List <UnvanDTO> UnvanList { get; set; }

        public List<UlkeDTO> UlkeList { get; set; }

        public List<PersonelSelect> YoneticiList{ get; set; }



    }
}