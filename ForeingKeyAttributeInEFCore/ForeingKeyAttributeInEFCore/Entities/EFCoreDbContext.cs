using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeingKeyAttributeInEFCore.Entities
{
    internal class EFCoreDbContext:DbContext
    {
        public EFCoreDbContext():base()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EFCoreDB1;
            //Trusted_Connection=True;TrustedServerCertificate=True;");
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();
            var configuration = configurationBuilder.GetSection("ConnectionStrings");
            var connectionString = configuration["SQLServerConnection"] ?? null;
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
