using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedureInEFCore.Entities
{
    internal class EFCoreDbContext:DbContext
    {
        public EFCoreDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
                .GetSection("ConnectionStrings")["SQLServerConnection"] ?? null;
            //var getSection = configBuilder.GetSection("ConnectionStrings")["SQLServerConnection"] ?? null;
            //var connString = getSection["SQLServerConnection"] ?? null;
            optionsBuilder.UseSqlServer(configBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
    }
}
