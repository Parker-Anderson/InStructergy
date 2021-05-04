using SchoolBoard.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.CourseModels
{
    public class CourseDetail
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<SchoolBoard.Data.DataModels.Student> Students { get; set; }
    }
}
