using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web.DynamicData;

namespace DbCodeFirst.Models.Data
{
    public class PerContext : DbContext
    {
        //Migration 
        //1.Enable-migrations  
        //2.Add-migration ilk
        //3.Update-Database
        //4. Gerekli ise 2. Adıma git.
        public PerContext()
            : base("Baglanti")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Personels in sonundaki s yi siler.
        }

       public virtual DbSet<Personel> Personel{ get; set; } //Personel tablosu ile Personel class ı arasında bağlantıyı sağlıyor.

    }
    [TableName("Personel")]/* veritabanını sonuna s takısı ekler bunu yazmazsak -> Personels gibi*/
    public class Personel
    {
        [Key]  // Üstüne koyulanı key yapar
        public int PersonelId { get; set; }
        public string Ad { get; set; }
        //sonradan Soyad eklersek-> 2. Adım a git Add-Migration soyadEklendi ->3. Adım Update-Database

        public string Soyad { get; set; }

    }
}