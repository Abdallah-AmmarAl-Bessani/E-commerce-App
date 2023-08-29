using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Data
{
    public class E_CommerceDBContext : DbContext
    {
        public E_CommerceDBContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasKey(x => new 
            {
                x.ID,
                x.CategoryID
            });
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Product> Product { get; set; }
    }
}
