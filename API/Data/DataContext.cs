using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
                    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(d => d.Name)
                      .IsUnique();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Salary)
                      .IsRequired()
                      .HasColumnType("decimal(18,4)");
            });
        }
    }

}