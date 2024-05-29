using SelfReferenceRelationshipUsingFluentAPI.Entities;

namespace SelfReferenceRelationshipUsingFluentAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EFCoreDbContext db = new EFCoreDbContext();
                Employee manager = new Employee()
                {
                    Name = "Sumit Kumar"
                };
                db.Add(manager);
                db.SaveChanges();

                Employee employee1 = new Employee()
                {
                    Name = "Hima",
                    Manager = manager
                };
                Employee employee2 = new Employee()
                {
                    Name = "Santosh",
                    Manager = manager
                };
                db.Add(employee1);
                db.Add(employee2);
                db.SaveChanges();
                Console.WriteLine("Data Added");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
            }
            Console.ReadKey();
        }
    }
}