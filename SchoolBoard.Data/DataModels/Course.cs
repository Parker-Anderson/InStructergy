using SchoolBoard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Data.DataModels
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        [ForeignKey(nameof(Instructor))]
        public string InstructorId { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
    }
}

