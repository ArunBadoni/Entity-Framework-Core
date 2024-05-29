using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FluentInterfaceDesignPattern.Models
{
    internal class Student
    {
        public string RegdNo { get; set; }
        public string? Name { get; set; }
        public DateTime DOB { get; set; }
        public string? Branch { get; set; }
        public string? Address { get; set; }

    }
    internal class FluentStudent
    {
        public Student studentDetails = new Student();
        public FluentStudent StudentRegedNumber(string RegdNo)
        {
            studentDetails.RegdNo = RegdNo;
            return this;
        }
        public FluentStudent NameOfTheStudent(string Name)
        {
            studentDetails.Name = Name;
            return this;
        }
        public FluentStudent BornOn(string DOB)
        {
            studentDetails.DOB = Convert.ToDateTime(DOB);
            return this;
        }
        public FluentStudent StudyOn(string Branch)
        {
            studentDetails.Branch = Branch;
            return this;
        }
        public FluentStudent StaysAt(string Address)
        {
            studentDetails.Address = Address;
            return this;
        }
    }
}
