using EagerLoadinginEFCore.Entities;

namespace LazyLoadingInEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var context = new EFCoreDbContext();

                var student = context.Students.FirstOrDefault(std=>std.StudentId == 1);
                Console.WriteLine($"StudentName:{student?.FirstName} {student?.LastName}\n\n");

                var standard = student?.Standard;
                Console.WriteLine($"StandardName:{standard?.StandardName} {standard?.Description}\n\n");

                var address = student?.StudentAddress;
                Console.WriteLine($"Address:{address?.Address1} {address?.Email}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}