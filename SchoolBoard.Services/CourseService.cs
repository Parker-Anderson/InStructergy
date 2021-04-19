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
                    .Courses
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
            var _studentService = new StudentService(_instructorId);
            var _courseService = new CourseService(_instructorId);
            var entity =
                new Course()
                {
                    InstructorGuid = _instructorId,
                    Id = model.Id,
                    Name = model.Name,
                    Student = model.Student,
                    Instructor = model.Instructor,

                    Students = model.Students,
                    
                    
                    
                };
            using (var context = new ApplicationDbContext())
            {
                context.Courses.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
        public CourseDetail GetCourseById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Courses
                    .Single(e => e.Id == id);
                return
                    new CourseDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Instructor = entity.Instructor,
                        InstructorGuid = entity.InstructorGuid,
                        InstructorId = entity.InstructorId,
                        Students = entity.Students
                    };
            }
        }
        

    }
   
}
