using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfReferenceRelationshipUsingFluentAPI.Entities
{
    internal class EFCoreDbContext:DbContext
    {
        public EFCoreDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();
            var configuration = configurationBuilder.GetSection("ConnectionString");
            var configString =configuration["SQLServerConnection"]??null;
            optionsBuilder.UseSqlServer(configString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(m => m.Manager)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.ManagerId).
                OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
