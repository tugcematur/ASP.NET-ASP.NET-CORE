using AdvancedRepository.Models.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedRepository.DTOs;

namespace AdvancedRepository.Models.Data
{
    public class SirketContext:DbContext
    {
        public SirketContext(DbContextOptions<SirketContext> op) : base(op)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<FatDetail>().HasKey(p => new { p.Id, p.ProductId });
            modelBuilder.Entity<BasketDetail>().HasKey(b => new { b.Id, b.ProductId });
        }
        public DbSet<Categories> Categories { get; set; }     //db.Categories public yaparsak kullanabiliriz
                                                              //db.Set<Categoriess>

        public DbSet<Cities> Cities { get; set; }
        public DbSet<Counties> Counties{ get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Units> Unit { get; set; }

        public DbSet<FatMaster> FatMaster { get; set; }

        public DbSet<FatDetail> FatDetail{ get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<BasketMaster> BasketMaster { get; set; }

        public DbSet<BasketDetail> BasketDetail { get; set; }
        //Enterprise bir tablo olmadığı için onu eklemedik!
    }
}
