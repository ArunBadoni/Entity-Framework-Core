using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeingKeyAttributeInEFCore.Entities
{
    internal class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public int EmployeeAge { get; set; }
        public Department? Department { get; set; }
    }
}
