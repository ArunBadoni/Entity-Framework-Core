using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagerLoadinginEFCore.Entities
{
    public class Student
    {
        //A private field for the ILazyLoader instance
        private readonly ILazyLoader _lazyLoader;

        //An empty constructor 
        public Student()
        {
        }

        //one parameterized that takes an ILazyLoader as a parameter to
        //Initialize the ILazyLoader instance
        public Student(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? StandardId { get; set; }

        //Private Field For Standard Navigation Property
        private Standard _Standard;
        
        //Public Setter and Getter Property for the Private _Standard Field
        public Standard Standard
        {
            get => _lazyLoader.Load(this, ref _Standard);
            set => _Standard = value;
        }
        
        //public virtual StudentAddress? StudentAddress { get; set; }
        //Private Field For StudentAddress Navigation Property
        private StudentAddress _StudentAddress;
        //Public Setter and Getter Property for the Private _StudentAddress Field
        public StudentAddress StudentAddress
        {
            get => _lazyLoader.Load(this, ref _StudentAddress);
            set => _StudentAddress = value;
        }
        
        //Private Field For Course Collection Navigation Property
        private ICollection<Course> _Courses = new List<Course>();
        //Public Setter and Getter Property for the Private _Courses Field
        public ICollection<Course> Courses
        {
            get => _lazyLoader.Load(this, ref _Courses);
            set => _Courses = value;
        }
    }
}
