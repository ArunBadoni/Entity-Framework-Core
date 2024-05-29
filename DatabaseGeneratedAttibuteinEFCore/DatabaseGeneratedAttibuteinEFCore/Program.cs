using DatabaseGeneratedAttibuteinEFCore.Entities;

namespace DatabaseGeneratedAttibuteinEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StudentDbContext context = new StudentDbContext();
                Student student = new Student()
                {
                    StudentId = 103,
                    FirstName = "Ramesh",
                    LastName = "Yadhav"
                };
                context.Students.Add(student);
                context.SaveChanges();

                Console.WriteLine("Data Inserted Successfully!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred!!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            Console.ReadKey();
        }
    }
}