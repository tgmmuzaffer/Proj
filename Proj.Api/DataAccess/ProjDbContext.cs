using Proj.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Proj.Api.DataAccess
{
    public class ProjDbContext: DbContext
    {
        public ProjDbContext(DbContextOptions<ProjDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne<Category>(s => s.Category)
                .WithMany(ad => ad.Products);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
