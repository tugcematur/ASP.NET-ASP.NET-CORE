﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Personel
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }


        public string FullName()
        {
            return Ad + Soyad;
        }
    }
}
