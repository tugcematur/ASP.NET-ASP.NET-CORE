using BasicRepository.Models.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BasicRepository.Models.Data
{
    public class PerContext :DbContext
    {
        //public PerContext():base("Baglanti")                                                //Bunlar Asp.Net de geçerli; Core da değil!!
        //{

        //}
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Students in sonundaki s yi siler.
        //}
        public PerContext(DbContextOptions<PerContext> options ) : base(options)
        {

        }

        public DbSet<Personel> Personel { get; set; }
        public DbSet<City> City { get; set; }
    }
}
