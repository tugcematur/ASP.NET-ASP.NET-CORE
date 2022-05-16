using OgrenciProjeCodeFirst.Models.Data;
using OgrenciProjeCodeFirst.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OgrenciProjeCodeFirst.Models.ViewModels
{
    public class StudentModel
    {
        public Student Student { get; set; }
        public string BtnVal { get; set; }
        public string BtnClass { get; set; }
        public string Baslik { get; set; }

        public  string InputType { get; set; }

        public List<CityDTO> CityList { get; set; }





    }
}