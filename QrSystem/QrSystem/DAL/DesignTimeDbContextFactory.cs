using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace QrSystem.DAL
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Data Source=SQL5106.site4now.net;Initial Catalog=db_aa64c4_qrsystem;User Id=db_aa64c4_qrsystem_admin;Password=ferid2003");

            return new AppDbContext(optionsBuilder.Options);
            //}
        }
    }
}
