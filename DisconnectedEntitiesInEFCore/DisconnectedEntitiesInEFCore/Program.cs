using DisconnectedEntitiesInEFCore.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;

namespace DisconnectedEntitiesInEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EFCoreDbContext dbContext = new EFCoreDbContext();
                Student student = new Student()
                { Id = 1 };

                //if (student.Id > 0)
                //{
                //    dbContext.Entry(student).State = EntityState.Modified;
                //}
                //else if (student.Id == 0)
                //{
                //    dbContext.Entry(student).State = EntityState.Added;
                //}
                //else
                //{
                //    Console.WriteLine("Invalid Student Id");
                //}


                //Setting the Entity State as Deleted
                dbContext.Entry(student).State = EntityState.Deleted;

                Console.WriteLine("Entity State before SaveChanges() : " + dbContext.Entry(student).State);

                dbContext.SaveChanges();

                Console.WriteLine("Entity State After SaveChanges() : " + dbContext.Entry(student).State);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception :"+ex.Message);
            }
        }
    }
}
