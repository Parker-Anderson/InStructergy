using SchoolBoard.Data;
using SchoolBoard.Data.DomainModels;
using SchoolBoard.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Services
{
    public class CourseService
    {
        private readonly Guid _instructorId;
        
        public CourseService(Guid userId)
        {
           
            _instructorId = userId;
        }
        public IEnumerable<CourseListItem> GetCourses()
        {
            using(var context = new ApplicationDbContext())
            {
                var query =
                    context
                    .Courses.Include("Students")
                    .Select(q => new CourseListItem
                    {
                        Id = q.Id,
                        Name = q.Name,
                        Instructor = q.Instructor,
                        InstructorId = q.InstructorId
                    });
                return query.ToArray();
                       
            }
        }
        public bool CreateCourse(CourseCreate model)
        {
            var ctx = new ApplicationDbContext();
            var _studentService = new StudentService(_instructorId);
            var _courseService = new CourseService(_instructorId);
            var entity =
                new Course()
                {
                    InstructorGuid = _instructorId,
                    Id = model.Id,
                    Name = model.Name,
                    Instructor = model.Instructor
                };

            using (var context = new ApplicationDbContext())
            {
                context.Courses.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
        public Course GetCourseById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
               var entity =
                    context
                    .Courses
                    .Single(e => e.Id == id);
                return entity;
            }
        }
        public bool AddStudent(Student student, int id)
        {
            
           
            
            using (var context = new ApplicationDbContext())
            {

                var course = context.Courses.Single(c => c.Id == id);
                course.Students.ToList().Add(student);
                return context.SaveChanges() == 1;

               
            }

        }


    }
   
}
