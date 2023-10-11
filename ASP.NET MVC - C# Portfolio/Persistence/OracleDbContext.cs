using ASP.NET_MVC___C__Portfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_MVC___C__Portfolio.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet <Games> Games { get; set; }

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>()
                .Property(g => g.Valor)
                .HasColumnType("decimal(6, 2)"); 

            base.OnModelCreating(modelBuilder);
        }

    }

    

}
