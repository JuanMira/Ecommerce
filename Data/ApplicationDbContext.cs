using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<HIstorial>? HIstorials { get; set; }
        public DbSet<Score>? Scores { get; set; }
        public DbSet<Role>? Roles { get; set; }

        // overrides

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().
                HasIndex(u => u.Username).
                IsUnique();
            builder.Entity<User>().
                HasIndex(u => u.Email).
                IsUnique();
        }
    }
}