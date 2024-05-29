using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagerLoadinginEFCore.Entities
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? StandardId { get; set; }
        public virtual Standard? Standard { get; set; }
        public virtual StudentAddress? StudentAddress { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
