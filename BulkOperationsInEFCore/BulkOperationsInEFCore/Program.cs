using BulkOperationsInEFCore.Entities;

namespace BulkOperationsInEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EFCoreDbContext db = new EFCoreDbContext();
            //    List<Student> students = new List<Student>
            //{
            //    new Student{StudentName="Arun Badoni",StudentEmail="arun.badoni@dxc.com",Branch="CSE"},
            //    new Student{StudentName="Krishni Badoni",StudentEmail="krishna.badoni@goole.com",Branch="Finance"},
            //    new Student{StudentName="Akshara Badoni",StudentEmail="akshara.badoni@amazon.com",Branch="Manager"},
            //    new Student{StudentName="Rakhi Badoni",StudentEmail="rakhi.badoni@gov.com",Branch="Officer"},
            //};
                BulkDelete("ToBeDeleted", db);
                //FetchData(students);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
            }
            Console.ReadKey(true);
        }
        static void BulkDelete(string name,EFCoreDbContext db)
        {
            var stuList = db.Students.Where(s=>s.StudentName==name).ToList();
            db.Students.RemoveRange(stuList);
            db.SaveChanges();
            Console.WriteLine("Data Deleted Successfully");
        }
        static void BulkUpdate(List<Student> students, EFCoreDbContext db)
        {
            foreach (Student student in students)
            {
                student.Branch += " Promoted";
            }
            db.SaveChanges();
            Console.WriteLine("Data Updated Successfully");
        }
        static void BulkInsert(List<Student> students,EFCoreDbContext db)
        {
            db.Students.AddRange(students);
            db.SaveChanges();
            Console.WriteLine("Data Inserted Successfully");
        }
        static void FetchData(List<Student> students)
        {
            Console.WriteLine("\nStudent Details:");
            foreach (var student in students)
            {
                Console.WriteLine("ID:"+student.StudentId +"\nName:"+student.StudentName+ "\nEmail:" + student.StudentEmail+ "\nBranch:" + student.Branch+ "\n\n");
            }
        }
    }
}