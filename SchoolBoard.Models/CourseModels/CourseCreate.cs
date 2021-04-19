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
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }

        public CourseCreate(int id, Student student, ApplicationUser instructor)
        {
            Id = id;
            Student = student;
            Instructor = instructor;
            var studentList = Students.ToList();
            studentList.Add(student);
            Students = studentList.ToArray();
        }
        public CourseCreate()
        {

        }
    }
}
