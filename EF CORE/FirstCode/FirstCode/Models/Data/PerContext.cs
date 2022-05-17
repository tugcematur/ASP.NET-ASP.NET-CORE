using FirstCode.Models.Data.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCode.Models.Data
{
    public class PerContext:DbContext
    {
       

        public PerContext(DbContextOptions<PerContext> options) : base(options) // Microsoft istiyor,birden fazla constructre olduğunda :base(options) dan dolayı  Önce bu çalışır
        {
          
        }

        public DbSet<Personel> Personel{ get;set; } 
        public DbSet<City> City { get; set; }

        //classsları  burda yazabiliriz.
        public PerContext()
        {

        }
    }
}
