using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitLoadingInEFCore.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int? TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
