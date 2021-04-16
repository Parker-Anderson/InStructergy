using SchoolBoard.Data;
using SchoolBoard.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.CourseModels
{
    public class CourseEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
