using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCwithRazor.Data
{
    public partial class Context : DbContext
    {
      

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Personel> Personels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-HRRA875\\SQLEXPRESS;Database=PerDbCore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityName).HasMaxLength(10);
            });

            modelBuilder.Entity<Personel>(entity =>
            {
                entity.ToTable("Personel");

                entity.HasIndex(e => e.CityId, "IX_Personel_CityId");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Personels)
                    .HasForeignKey(d => d.CityId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
