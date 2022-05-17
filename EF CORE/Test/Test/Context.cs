using Microsoft.EntityFrameworkCore;

namespace Test
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> db) : base(db)
        {

        }

        public class Personel
        {
            public int Id { get; set; }
            public string Name { get; set; } = null!; //  veya  = string.Empty

        

        }


        public DbSet<Personel> Personels { get; set; } // aynı sayfada yaptığımız için class tan farklı olmalı ismi
    }
}
