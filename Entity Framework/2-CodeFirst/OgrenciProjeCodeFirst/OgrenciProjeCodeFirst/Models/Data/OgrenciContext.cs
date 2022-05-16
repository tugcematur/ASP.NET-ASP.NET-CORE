using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace OgrenciProjeCodeFirst.Models.Data
{
    public class OgrenciContext : DbContext
    {
        
        public OgrenciContext()
            : base("Baglanti")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Students in sonundaki s yi siler.
        }

       public virtual DbSet<Student> Student { get; set; }
       public virtual DbSet<City> City{ get; set; }
        public virtual DbSet<Teacher> Teacher {get; set;}
    }


    abstract  public class Base   // Şablon, db de yer almaz , program içinde new lememek içn abstract yapabiliriz
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CityId { get; set; }

        public string MotherName { get; set; }

        public string FullName ()
        {
            return this.Name + " " + this.Surname;
        }


        [ForeignKey("CityId")] //Bağlantının üstünde olmalı!
        public virtual City City { get; set; } // Core da virtual a gerek yok  Her Öğrencinin 1 city si var                 //Bağlantı
    }


    public class Student :Base
    {
      
    }


    public class Teacher:Base
    {
        public decimal Salary { get; set; }
    }


    public class City
    {
        public City()                //Koleksiyon için consturcture yazıyoruz, Core da gerek yok
        {
            this.Students = new HashSet<Student>();  // Performans açısından kullanlır. ICollection yerine HashSet kullanılıyor.
            this.Teachers = new HashSet<Teacher>();
        }
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
       
        public virtual  ICollection <Student> Students{ get; set; } // Bir City e 1 den fazla Student bağlı olabilir              //Bağlantı
        public virtual ICollection<Teacher> Teachers { get; set; } 
    }
}