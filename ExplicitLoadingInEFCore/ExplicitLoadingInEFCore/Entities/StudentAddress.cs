using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitLoadingInEFCore.Entities
{
    public class StudentAddress
    {
        [Key]
        public int StudentId { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public virtual Student Student { get; set; } = null!;
    }
}
