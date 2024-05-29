using LinqInEFCore.Entities;
using System.Runtime.CompilerServices;

namespace LinqInEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var context = new EFCoreDbContext();

                var joinUsingMS = context.Students.Join(context.Standards,
                    student => student.Standard.StandardId,
                    Standard => Standard.StandardId,
                    (student,standard)=>new
                    {
                        StudentName = student.FirstName +" "+student.LastName,
                        standrdId = standard.StandardId,
                        StudentHeight = student.Height
                    }).ToList();

                foreach (var student in joinUsingMS)
                {
                    Console.WriteLine($"Name : {student?.StudentName}, Height : {student?.StudentHeight}, Standard : {student?.standrdId}");
                }

                Console.WriteLine("---------------------------------------");

                var joinUsigQS = (from student in context.Students
                                  join standard in context.Standards
                                  on student.Standard.StandardId equals standard.StandardId
                                  select new
                                  {
                                      sName = student.FirstName+" "+student.LastName,
                                      sHeight = student.Height,
                                      standardId = standard.StandardId
                                  }).ToList();

                foreach (var student in joinUsigQS)
                {
                    Console.WriteLine($"Name : {student?.sName}, Height : {student?.sHeight}, Standard : {student.standardId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}