using SchoolBoard.Data;
using SchoolBoard.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.StudentModels
{
    public class StudentDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid InstructorId { get; set; }
        public IEnumerable<ApplicationUser> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<File> Files { get; set; }
        public double GradePointAverage { get; set; }
    }
}
