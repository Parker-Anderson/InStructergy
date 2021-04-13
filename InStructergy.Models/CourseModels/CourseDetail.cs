using InStructergy.Data;
using InStructergy.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InStructergy.Models.CourseModels
{
    public class CourseDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InstructorId { get; set; }
        public Guid InstructorGuid { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
        public List<Student> Students { get; set; }
    }
}
