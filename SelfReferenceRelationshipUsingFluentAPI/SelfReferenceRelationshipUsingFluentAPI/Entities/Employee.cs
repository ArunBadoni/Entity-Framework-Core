using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfReferenceRelationshipUsingFluentAPI.Entities
{
    internal class Employee
    {
        public int EmployeeId { get;set; }
        public string? Name { get;set; }
        public int? ManagerId { get;set; }
        public Employee? Manager { get;set; }
        public List<Employee>? Subordinates { get;set;}
    }
}
