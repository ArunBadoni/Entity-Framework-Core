using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGeneratedAttibuteinEFCore.Entities
{
    internal class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SequenceNumber { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string? FullName { get; set; }
    }
}
