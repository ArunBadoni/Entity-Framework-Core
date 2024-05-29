using FluentInterfaceDesignPattern.Models;

namespace FluentInterfaceDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FluentStudent student = new FluentStudent();
            student.StudentRegedNumber("BQPPR123456")
                   .NameOfTheStudent("Arun Badoni")
                   .BornOn("14/12/1995")
                   .StudyOn("CSE")
                   .StaysAt("Uttarkashi, Uttrakhand");
            Student student1 = student.studentDetails;
            Console.WriteLine(student1.RegdNo+ " "+student1.Name + " " + student1.DOB + " " + student1.Branch + " " + student1.Address);

            Console.Read();

        }
    }
    
}