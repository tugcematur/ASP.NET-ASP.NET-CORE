using System;
using System.Collections.Generic;

namespace MVCwithRazor.Data
{
    public partial class Personel
    {
        public int PersonelId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int CityId { get; set; }

        public virtual City City { get; set; } = null!;
    }
}
