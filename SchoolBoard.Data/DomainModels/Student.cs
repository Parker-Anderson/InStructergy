using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Data.DomainModels
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<ApplicationUser> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }
        public double GradePointAverage { get; set; }
        public ApplicationUser Instructor { get; set; }
        public string InstructorId { get { return Instructor.Id; } }
        public Guid InstructorGuid { get; set; }
    }
}
