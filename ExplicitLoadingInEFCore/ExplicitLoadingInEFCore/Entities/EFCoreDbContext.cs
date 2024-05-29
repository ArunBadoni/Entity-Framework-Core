using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitLoadingInEFCore.Entities
{
    internal class EFCoreDbContext:DbContext
    {
        public EFCoreDbContext() : base()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //To Display the Generated the Database Script
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            //Enabling Lazy Loading
            //optionsBuilder.UseLazyLoadingProxies();

            //Configuring the Connection String
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EFCoreDB1;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        //OnModelCreating() method is used to configure the model using ModelBuilder Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Use this to configure the model using Fluent API
        }
        //Adding Domain Classes as DbSet Properties
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Standard> Standards { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentAddress> StudentAddresses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
    }
}
