using InStructergy.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InStructergy.Models
{
    public class CourseCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string InstructorId { get; set; }
        //constraints on the Students property can be set here through annotation.
        public List<Student> Students { get; set; }
    }
}
