using KatmanliMimari.Dal;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KatmanliMimari.Entity;
using KatmanliMimari.Dal.Users;

namespace KatmanliMimari.UI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        KatmanliDbContext _db;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, KatmanliDbContext db)
            : base(options)
        {
            _db = db;
        }
        public DbSet<KatmanliMimari.Entity.Categories> Categories { get; set; } // List view ini oluşturduktan sonra kendisi otomatik geliyor
    }
}