using OneToOneRelationUsingFluentAPI.Entities;

namespace OneToOneRelationUsingFluentAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EFCoreDbContext eFCoreDbContext = new EFCoreDbContext();

            Passport passport = new Passport() { PassportNumber = "Pass-1224-xyz" };
            Person person = new Person() { Name="Arun Badoni",Passport=passport};

            eFCoreDbContext.Add(person);
            eFCoreDbContext.SaveChanges();
            Console.WriteLine("Data Saved");
        }
    }
}