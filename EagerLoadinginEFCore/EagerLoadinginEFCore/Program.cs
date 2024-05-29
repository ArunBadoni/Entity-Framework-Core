using EagerLoadinginEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace EagerLoadinginEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new EFCoreDbContext();

            /* Include() method Note: Use anyone of the below "var students" query
            
            //var students = context.Students.Include(std=>std.Standard).ToList();
            
            //var students = context.Students.Include("Standard").ToList();

            //var students = (from s in context.Students.Include(std => std.Standard)
            //                select s).ToList();

            var students = (from s in context.Students.Include("Standard")
                            select s).ToList();

            foreach (var student in students)
            {
                Console.WriteLine($"StudentName:{student.FirstName} {student.LastName},  Standard Description: {student.Standard?.Description}");
            }*/

            /* Using FromSQL method
            FormattableString sql = $"select * from Students where FirstName = 'Hina'";
            var StudentWithStandard = context.Students.FromSql(sql)
                .Include(std => std.Standard).FirstOrDefault();

            Console.WriteLine($"Firstname: {StudentWithStandard?.FirstName}, Lastname: {StudentWithStandard?.LastName}, " +
                    $"StandardName: {StudentWithStandard?.Standard?.StandardName}, Description: {StudentWithStandard?.Standard?.Description}");
            */

            /*Load Multiple Related Entities Using Include Method
            //var query = context.Students
            //    .Include(std => std.Standard)
            //    .Include(std => std.StudentAddress)
            //    .Include(std => std.Courses).ToList();

            var query = (from s in context.Students
                         .Include(std=>std.Standard)
                         .Include(std=>std.StudentAddress)
                         .Include(std=>std.Courses)
                         select s).ToList();

            foreach (var item in query)
            {
                Console.WriteLine($"StudentName:{item.FirstName} {item.LastName}, Address:{item.StudentAddress?.Address1}");
                foreach (var course in item.Courses)
                {
                    Console.WriteLine($"\t CourseName : {course.CourseName}");
                }
            }
            */

            var student = context.Students.Where(s=>s.FirstName== "Pranaya")
                .Include(s => s.Standard)
                .ThenInclude(std => std.Teachers).FirstOrDefault();
            
            Console.WriteLine($"StudentName:{student?.FirstName}, StandardName : {student?.Standard?.StandardName}");
            
            if (student?.Standard != null)
            {
                foreach (var teacher in student.Standard.Teachers)
                {
                    Console.WriteLine($"TeacherId : {teacher.TeacherId}, TeacherName:{teacher.FirstName}");
                }
            }
            
            Console.ReadKey();
        }
    }
}