using SchoolBoard.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Data.DataModels
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
    }
}