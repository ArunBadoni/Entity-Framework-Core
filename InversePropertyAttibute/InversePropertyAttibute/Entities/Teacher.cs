using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversePropertyAttibute.Entities
{
    internal class Teacher
    {
        public int TeacherId { get; set; }
        public string? Name { get; set; }
        [InverseProperty("OnlineTeacher")]
        public ICollection<Course>? OnlineCourses { get; set; }
        [InverseProperty("OfflineTeacher")]
        public ICollection<Course>? OfflineCourses { get; set; }
    }
}
