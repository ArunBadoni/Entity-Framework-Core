using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManayToManyRelationshipUsingFluentAPI.Entities
{
    internal class EFCoreDbContext:DbContext
    {
        public EFCoreDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuationBuilder = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();
            var configuration = configuationBuilder.GetSection("ConnectionStrings");
            var configString = configuration["SQLServerConnection"]??null;
            optionsBuilder.UseSqlServer(configString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(c => c.Courses)
                .WithMany(s => s.Students)
                .UsingEntity(j => j.ToTable("StudentCourses"));
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
