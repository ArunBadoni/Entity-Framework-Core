using DBFirstApproach.Models;
using Microsoft.EntityFrameworkCore;

namespace DBFirstApproach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbfirstEfcoreApproachContext context = new DbfirstEfcoreApproachContext();

            /*Adding Department data 
            Department itdepartment = new Department()
            {
                DepartmentName = "IT Department"
            };
            Department hrdepartment = new Department()
            {
                DepartmentName = "HR Department"
            };
            context.Add(itdepartment);
            context.Add(hrdepartment);
            context.SaveChanges();


            List<Department> departments = context.Departments.ToList();
            Console.WriteLine("Department Details:");
            foreach (var department in departments)
            {
                Console.WriteLine($"Department Id: {department.DepartmentId}\nDepartment Name : {department.DepartmentName}");
            }*/



            /* Adding and fetching Employee data
            Employee employee1 = new Employee()
            {
                FirstName = "Arun",
                LastName = "Badoni",
                Email = "arunbadoni@gmail.com",
                Salary = 120000,
                Department = context.Departments.FirstOrDefault(x=>x.DepartmentName== "IT Department")
            };
            Employee employee2 = new Employee()
            {
                FirstName = "Rohan",
                LastName = "Kumar",
                Email = "RohanK25@gmail.com",
                Salary = 90000,
                Department = context.Departments.FirstOrDefault(x => x.DepartmentName == "HR Department")
            };
            context.Employees.Add(employee1);
            context.Employees.Add(employee2);
            context.SaveChanges();
            List<Employee> employees = context.Employees.ToList();
            Console.WriteLine("Employee Details:\n");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee Id: {employee.EmployeeId}\nEmployee Name : {employee.FirstName} {employee.LastName}\n" +
                    $"Email : {employee.Email}\nSalary : {employee.Salary}\nDepartment Name: {employee?.Department?.DepartmentName}\n\n");
            }*/

            /*Fetching data using EmployeeDetail view
            List<EmployeeDetail> employeeDetail = context.EmployeeDetails.ToList();
            foreach (var employee in employeeDetail)
            {
                Console.WriteLine($"Employee Id: {employee.EmployeeId}\nEmployee Name : {employee.FirstName} {employee.LastName}\n" +
                    $"Email : {employee.Email}\nSalary : {employee.Salary}\nDepartment Name: {employee.DepartmentName}\n\n");
            }*/

            //Calling CalculateBonus function
            var employee = context.Employees
                .Where(e => e.EmployeeId == 1)
                .Select(d => new
                {
                    Name = d.FirstName + " " + d.LastName,
                    Salary = d.Salary,
                    DepartmentName = d.Department.DepartmentName,
                    Bonus = DbfirstEfcoreApproachContext.CalculateBonus(d.EmployeeId)
                }).FirstOrDefault();


            Console.WriteLine($"Employee Name : {employee.Name}\n" +
                    $"Salary : {employee.Salary}\nDepartment Name: {employee.DepartmentName}\nBonus : {employee.Bonus}\n\n");
            


            Console.ReadKey();
        }
        
    }
}
