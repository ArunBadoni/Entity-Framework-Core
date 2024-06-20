using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedDataInEFCore.Entities
{
    internal class EFCoreDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();
            var connString = configurationBuilder.GetSection("ConnectionString")["SQLServerConnection"] ?? null;
            optionsBuilder.UseSqlServer(connString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new() { CountryId=1, CountryName="India",CountryCode="IND"},
                new() { CountryId = 2, CountryName = "Australia", CountryCode = "AUS" }
            );

            modelBuilder.Entity<State>().HasData(
                new() { StateId=1,StateName="Uttranchal",CountryId=1},
                new() { StateId = 2, StateName = "Delhi", CountryId = 1 }
                );
            modelBuilder.Entity<City>().HasData(
                new() { CityId=1,CityName="Dehradun",StateId=1},
                new() { CityId = 2, CityName = "Saket", StateId = 2 }
                );
        }
        public DbSet<Country> CountryMaster { get; set; }
        public DbSet<State> StateMaster { get; set; }
        public DbSet<City> CityMaster { get;set; }
    }
}
