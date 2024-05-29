using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitLoadingInEFCore.Entities
{
    public class Standard
    {
        public int StandardId { get; set; }
        public string? StandardName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
