using FirstEFCoreApp.Entities;

namespace FirstEFCoreApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /* For Insert new Student
                Student student = new Student()
                {
                    FirstName = "Chatrapati",
                    LastName = "Shivaji",
                    DateOfBirth = DateTime.Now.AddYears(-14),
                    Height = 13,
                    Weight = 17,
                    Standard = null
                };
                var context = new EFCoreDbContext();
                //context.Add(student);
                //context.Students.Add(student);
                context.Add<Student>(student);

                //Now the Entity State will be in Added State
                Console.WriteLine($"Before SaveChanges Entity State: {context.Entry(student).State}");

                context.SaveChanges();

                //Now the Entity State will change from Added State to Unchanged State
                Console.WriteLine($"After SaveChanges Entity State: {context.Entry(student).State}");

                Console.WriteLine("Student Data Saved Successfully");
                Console.ReadLine();
                */

                /* For Update Existing Student
                var context = new EFCoreDbContext();
                Student student = context.Students.Find(7);
                if(student != null) 
                {
                    Console.WriteLine($"Entity State Before Update:{context.Entry(student).State}");
                    student.FirstName = "Deleting";
                    student.LastName = "Entry";
                    Console.WriteLine($"Entity State After Update:{context.Entry(student).State}");
                    context.SaveChanges();
                    Console.WriteLine($"Entity State After SaveChanges:{context.Entry(student).State}");
                    Console.WriteLine("Student Entry Updated Successfully");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("No Student Found");
                }
                */

                var context = new EFCoreDbContext();
                Student student = context.Students.Find(7);
                if (student != null)
                {
                    Console.WriteLine($"Entity State Before Update:{context.Entry(student).State}");
                    context.Students.Remove(student);

                    Console.WriteLine($"Entity State After Update:{context.Entry(student).State}");
                    context.SaveChanges();
                    Console.WriteLine($"Entity State After SaveChanges:{context.Entry(student).State}");
                    Console.WriteLine("Student Entry Deleted Successfully");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("No Student Found");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : "+ex);
                Console.ReadLine();
            }
        }
    }
}