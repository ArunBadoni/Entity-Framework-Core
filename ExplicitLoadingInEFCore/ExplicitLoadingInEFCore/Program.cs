using ExplicitLoadingInEFCore.Entities;

namespace ExplicitLoadingInEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var context = new EFCoreDbContext();
                //Loading the particular student data only
                //Here, it will only load the Student Data, no related entities
                Student? student = context.Students.FirstOrDefault(std => std.StudentId == 1);
                Console.WriteLine($"Firstname: {student?.FirstName}, Lastname: {student?.LastName}");
                Console.WriteLine();
                
                //Load Standard Explicit using the Load Method
                //If the related Property is a Reference type, 
                //First, call the Reference method by passing the property name that you want to load
                //and then call the Load Method
                if (student != null)
                {
                    //At this point the related Standard Entity is Loaded
                    context.Entry(student).Reference(s => s.Standard).Load();
                }
                //Printing the Standard Data
                if (student?.Standard != null)
                {
                    Console.WriteLine("Standard Entity is Loaded");
                    Console.WriteLine($"StandardName: {student.Standard.StandardName}, Description: {student.Standard.Description}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Standard Entity is not Loaded");
                    Console.WriteLine();
                }


                if (student != null)
                {
                    // At this point the related Courses Entities are Loaded
                    context.Entry(student).Collection(s => s.Courses).Load();
                }
                //Printing the Courses Data
                if (student?.Courses != null)
                {
                    Console.WriteLine("Courses Entities are Loaded");
                    foreach (var course in student.Courses)
                    {
                        Console.WriteLine($"CourseName: {course.CourseName}");
                    }
                }
                else
                {
                    Console.WriteLine("Courses Entities are not Loaded");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); ;
            }
            Console.ReadKey();
        }
    }
}