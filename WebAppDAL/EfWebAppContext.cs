using Microsoft.EntityFrameworkCore;
using WebAppDAL.Entities;

namespace WebAppDAL
{
    public class EfWebAppContext : DbContext
    {
        public DbSet<ProductDto> Products { get; set; }

        public EfWebAppContext(DbContextOptions<EfWebAppContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
