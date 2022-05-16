using Microsoft.EntityFrameworkCore;

namespace MultiRelations.Models.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> db) : base(db)
        {

        }


        public DbSet<Ogrenci> ?Ogrenciler { get; set; }   // Class lar ile Aynı Namespace içinde olduğundan aynı ismi veremiyoruz.
        public DbSet<Egitmen> ?Egitmenler { get; set; }

        //Çoka- Çok ilişki
        public class Ogrenci
        {
            public Ogrenci()
            {
                Egitmenler = new HashSet<Egitmen>();
            }
            public int Id { get; set; }
            public string? Name { get; set; }
            public ICollection<Egitmen> Egitmenler { get; set; }
        }


        public class Egitmen
        {
         
            public int Id { get; set; }
            public string? EgitmenAd { get; set; }
            public ICollection<Ogrenci> Ogrenciler { get; set; } = new HashSet<Ogrenci>();  // Bu şekilde de yazabiliriz 

        }
    }
}
