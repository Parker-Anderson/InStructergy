using SchoolBoard.Models.StudentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.CourseModels
{
    public class CourseStudentListModel
    {
   
        public IEnumerable<StudentListItem> Students { get; set; }
    }
}
