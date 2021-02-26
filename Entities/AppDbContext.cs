using Entities.Configurations;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfigurations());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
