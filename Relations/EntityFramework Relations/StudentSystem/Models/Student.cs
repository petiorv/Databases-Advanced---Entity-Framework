using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? Birthday { get; set; }
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();
    }
}
