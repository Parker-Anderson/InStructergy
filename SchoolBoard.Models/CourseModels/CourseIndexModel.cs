using SchoolBoard.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.CourseModels
{
    public class CourseIndexModel
    {
        public virtual IEnumerable<CourseListItem> Courses { get; set; }
    }
}
