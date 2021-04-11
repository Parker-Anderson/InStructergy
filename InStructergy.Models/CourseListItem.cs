using InStructergy.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InStructergy.Models
{
    public class CourseListItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        [Display(Name = "Students Enrolled")]
        public List<Student> Students { get; set; }
    }
}
