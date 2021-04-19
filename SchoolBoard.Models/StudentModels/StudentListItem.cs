using SchoolBoard.Data.DomainModels;
using SchoolBoard.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.StudentModels
{
    public class StudentListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual CourseListItem Course { get; set; }
        public int CourseId { get; set; }
        public virtual IEnumerable<Course> Courses { get; set; }
        public Guid InstructorGuid { get; set; }

    }
}
