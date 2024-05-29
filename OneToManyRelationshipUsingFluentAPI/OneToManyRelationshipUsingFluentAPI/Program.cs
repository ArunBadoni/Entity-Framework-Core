using OneToManyRelationshipUsingFluentAPI.Entities;

namespace OneToManyRelationshipUsingFluentAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EFCoreDbContext eFCoreDbContext = new EFCoreDbContext();

                //For Adding data
                //List<Book> books = new List<Book> {
                //    new Book() { Title = "C#" },
                //    new Book() {Title=".NET Core"},
                //    new Book() {Title="SQL Server"}
                // };
                //Author author = new Author() { Name = "Arun Badoi", Books = books };
                //eFCoreDbContext.Add(author);

                Author? author = eFCoreDbContext.Authors.Find(1);
                if(author != null) 
                {
                    eFCoreDbContext.Remove(author);
                    eFCoreDbContext.SaveChanges();
                }

                Console.WriteLine("Data Deleted Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:"+ex.Message);
            }
            Console.ReadKey();
        }
    }
}