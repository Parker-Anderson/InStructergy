using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InStructergy.Data.EntityModels
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid InstructorId { get; set; }
        public List<ApplicationUser> Instructors { get; set; }
        public List<Course> Courses { get; set; }
        public List<File> Files { get; set; }
        public double GradePointAverage { get; set; }
    }
}
