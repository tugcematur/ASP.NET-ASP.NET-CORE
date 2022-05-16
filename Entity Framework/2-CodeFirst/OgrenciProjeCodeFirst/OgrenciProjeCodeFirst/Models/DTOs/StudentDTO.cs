using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OgrenciProjeCodeFirst.Models.DTOs
{
    public class StudentDTO
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mothername { get; set; }
        public string CityName { get; set; }

    }
}