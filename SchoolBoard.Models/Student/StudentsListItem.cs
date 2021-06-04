using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Models.Student
{
    public class StudentsListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CourseModels.CourseListItem Course { get; set; }
    }
}
