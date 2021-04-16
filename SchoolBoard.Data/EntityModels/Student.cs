using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Data.EntityModels
{
    //Can optionally also be thought of as "Board" (i.e. the individual discussion board centered around that specific student)
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid InstructorId { get; set; }
        public IEnumerable<ApplicationUser> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<File> Files { get; set; }
        public double GradePointAverage { get; set; }
    }
}
