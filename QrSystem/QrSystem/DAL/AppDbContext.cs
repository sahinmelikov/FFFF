using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QrSystem.Models;
using QrSystem.Models.Auth;


namespace QrSystem.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<RestourantTables> Tables { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<QrCode> QrCodes { get; set; }
        public DbSet<SaxlanilanSifarish> SaxlanilanS { get; set; }
        public DbSet<ParentCategory> ParentsCategories { get; set; }
        public DbSet<Restorant>Restorant{ get; set; }
    }
}
