using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisconnectedEntitiesInEFCore.Entities
{
    internal class EFCoreDbContext:DbContext
    {
        public EFCoreDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConfigBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connSection = ConfigBuilder.GetSection("ConnectionStrings");
            var conString = connSection["SQLServerConnection"] ?? null;
            optionsBuilder.UseSqlServer(conString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
    }
}
