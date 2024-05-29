using ManayToManyRelationshipUsingFluentAPI.Entities;

namespace ManayToManyRelationshipUsingFluentAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EFCoreDbContext dbContext = new EFCoreDbContext();
                var courses = new List<Course>()
                {   
                    new Course { Title="Math",Description="All Basics"},
                    new Course { Title="English",Description="Expert"}
                };
                Student student = new Student() { StudentName = "Akshara Badoni", Courses = courses };
                dbContext.Add(student);
                dbContext.SaveChanges();
                Console.WriteLine("Student Added");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : "+ex.Message);
            }
            Console.ReadKey();
        }
    }
}