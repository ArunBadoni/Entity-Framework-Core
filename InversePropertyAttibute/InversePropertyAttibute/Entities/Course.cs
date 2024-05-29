using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversePropertyAttibute.Entities
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public Teacher? OnlineTeacher { get; set; }
        public Teacher? OfflineTeacher { get; set; }
    }
}
