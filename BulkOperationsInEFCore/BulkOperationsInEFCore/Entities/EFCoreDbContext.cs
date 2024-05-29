using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkOperationsInEFCore.Entities
{
    internal class EFCoreDbContext:DbContext
    {
        public EFCoreDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configurationBuilder = 
                new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();
            var configuration = configurationBuilder.GetSection("ConnectionString");
            var configString = configuration["SQLServerConnection"];
            optionsBuilder.UseSqlServer(configString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
