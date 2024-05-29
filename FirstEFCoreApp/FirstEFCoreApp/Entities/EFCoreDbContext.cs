using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEFCoreApp.Entities
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext():base()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //To Display the Generated the Database Script
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EFCoreDB1;
            //Trusted_Connection=True;TrustServerCertificate=True;");
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var configuration = configurationBuilder.GetSection("ConnectionStrings");
            var connectionString = configuration["SQLServerConnection"] ?? null;
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
    }
}
