using SchoolBoard.Data;
using SchoolBoard.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.StudentModels
{
    public class MyStudentListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public string InstructorId { get; set; }
        public ApplicationUser Instructor { get; set; }
    }
}
