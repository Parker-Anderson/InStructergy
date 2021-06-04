using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Models.Student
{
    public class CourseStudentIndexModel
    {
        public IEnumerable<StudentsListItem> Students { get; set; }
    }
}
