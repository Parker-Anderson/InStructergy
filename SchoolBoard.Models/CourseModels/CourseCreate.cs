using SchoolBoard.Data;
using SchoolBoard.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.CourseModels
{
    public class CourseCreate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public Guid InstructorGuid { get; set; }


        public CourseCreate()
        {

        }
    }
}
