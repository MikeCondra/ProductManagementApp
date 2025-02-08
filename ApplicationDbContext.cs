using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;

namespace ProductManagementApp
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(
                "Server=localhost;Database=products;User=root;Password=KjUbXtCrBtJcYjDs123!;",
                ServerVersion.AutoDetect("Server=localhost;Database=products;User=root;Password=KjUbXtCrBtJcYjDs123!;")
            );

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // This is a fallback if the context is not configured externally
                optionsBuilder.UseMySql(
                    "Server=localhost;Database=products;User=root;Password=KjUbXtCrBtJcYjDs123!;",
                    ServerVersion.AutoDetect("Server=localhost;Database=products;User=root;Password=KjUbXtCrBtJcYjDs123!;")
                );
            }
        }
    }
}
