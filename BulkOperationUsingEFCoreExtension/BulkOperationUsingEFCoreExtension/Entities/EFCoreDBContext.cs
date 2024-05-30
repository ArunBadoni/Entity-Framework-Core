using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkOperationUsingEFCoreExtension.Entities
{
    internal class EFCoreDBContext:DbContext
    {
        public EFCoreDBContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConfigurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var config = ConfigurationBuilder.GetSection("ConnectionStrings");
            var connString = config["SQLServerConnection"] ?? null;
            optionsBuilder.UseSqlServer(connString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
