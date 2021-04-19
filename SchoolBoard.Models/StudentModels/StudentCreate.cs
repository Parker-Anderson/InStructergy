using SchoolBoard.Data;
using SchoolBoard.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.StudentModels
{
    public class StudentCreate
    {
        public string Name { get; set; }
        public  IEnumerable<ApplicationUser> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public double GradePointAverage { get; set; }
        public string InstructorId { get; set; }
        public ApplicationUser Instructor { get; set; }
    }
}
