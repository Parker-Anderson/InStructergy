using SchoolBoard.Data;
using SchoolBoard.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.CourseModels
{
    public class CourseListItem
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<SchoolBoard.Data.DataModels.Student> Students { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
    }
}

