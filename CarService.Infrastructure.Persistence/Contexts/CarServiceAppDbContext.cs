using System.Reflection;
using CarService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.Infrastructure.Persistence.Contexts
{
    public class CarServiceAppDbContext : DbContext
    {
        public DbSet<CarProduct> CarProduct { get; set; }

        public CarServiceAppDbContext(DbContextOptions<CarServiceAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
