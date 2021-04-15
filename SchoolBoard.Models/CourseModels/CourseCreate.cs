using SchoolBoard.Data;
using SchoolBoard.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.CourseModels
{
    public class CourseCreate
    {
        public string Name { get; set; }
        public string InstructorId { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
        public Guid InstructorGuid { get; set; }
        public List<Student> Students { get; set; }
    }
}
