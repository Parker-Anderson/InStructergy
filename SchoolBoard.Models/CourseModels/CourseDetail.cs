using SchoolBoard.Data;
using SchoolBoard.Data.EntityModels;
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
        public string Name { get; set; }
        public string InstructorId { get; set; }
        public Guid InstructorGuid { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
