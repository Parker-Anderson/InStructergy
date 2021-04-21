using SchoolBoard.Models.StudentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.CourseModels
{
    public class CourseStudentModel
    {
        public CourseListItem Course { get; set; }
        public IEnumerable<StudentListItem> Students { get; set; }
    }
}
