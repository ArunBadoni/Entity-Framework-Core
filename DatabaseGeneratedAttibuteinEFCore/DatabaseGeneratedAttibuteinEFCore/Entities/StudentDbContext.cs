using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGeneratedAttibuteinEFCore.Entities
{
    internal class StudentDbContext:DbContext
    {
        public StudentDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MyDatabase;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Student>()
                .Property(u => u.CreatedDate)
                .HasComputedColumnSql("GETUTCDATE()");

            modelBuilder.Entity<Student>()
                .Property(p => p.FullName)
                .HasComputedColumnSql("[FirstName]+' '+[LastName]");
        }
        public DbSet<Student> Students { get; set; }
    }
}
