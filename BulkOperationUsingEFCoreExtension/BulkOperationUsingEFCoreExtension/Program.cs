using BulkOperationUsingEFCoreExtension.Entities;

namespace BulkOperationUsingEFCoreExtension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var context = new EFCoreDBContext();
                //Create a List of Students and Bulk Insert 
                /*
                List<Student> newStudents = new List<Student>() {
                    new Student() { FirstName = "Pranaya", LastName = "Rout", Branch= "CSE" },
                    new Student() { FirstName = "Hina", LastName = "Sharma", Branch= "CSE"  },
                    new Student() { FirstName = "Anurag", LastName= "Mohanty", Branch= "CSE" },
                    new Student() { FirstName = "Prity", LastName= "Tiwary", Branch= "ETC" }
                };
                context.BulkInsert(newStudents);
                Console.WriteLine("Student data inserted successfully");*/


                //Bulk Update Code
                /*var students =context.Students.Where(s => s.Branch == "CSE");
                foreach (var student in students)
                {
                    student.LastName += " changed";
                }
                context.BulkUpdate(students);
                Console.WriteLine("Student data updated successfully");*/

                var students = context.Students.Where(s => s.Branch == "CSE");
                context.BulkDelete(students);
                Console.WriteLine("Student data updated successfully");
                GetStudents("CSE", context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void GetStudents(string Branch,EFCoreDBContext context)
        {
            var students = context.Students.Where(s=>s.Branch==Branch);
            Console.WriteLine("Student having branch as CSE:\n");
            foreach (var student in students)
            {
                Console.WriteLine($"Student Id : {student.StudentId}\n StudentName : {student.FirstName} {student.LastName}\n Branch : {student.Branch}\n\n");
            }
        }
    }
}
