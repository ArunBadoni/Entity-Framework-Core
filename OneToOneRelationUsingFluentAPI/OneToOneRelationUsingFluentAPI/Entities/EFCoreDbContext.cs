using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneRelationUsingFluentAPI.Entities
{
    internal class EFCoreDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EFCoreDB1;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Passport)//Person has one Passport
                .WithOne(p => p.Person)//Passport is associated with one Person
                .HasForeignKey<Passport>(p => p.PersonId);//Foreign key in Passport table
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Passport> Passport { get; set;}
    }
}
