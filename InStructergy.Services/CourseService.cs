using InStructergy.Data;
using InStructergy.Data.EntityModels;
using InStructergy.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InStructergy.Services
{
    public class CourseService
    {
        private readonly Guid _userId;
        public CourseService(Guid userId)
        {
            userId = _userId;
        }
        public bool CreateCourse(CourseCreate model)
        {
            var entity =
                new Course()
                {
                    InstructorId = model.InstructorId,
                    InstructorGuid = Guid.Parse(model.InstructorId),
                    Instructor = model.Instructor,
                    Name = model.Name,
                    Students = model.Students,
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Courses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CourseListItem> GetCourses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Courses
                    .Where(e => e.InstructorGuid == _userId)
                    .Select(
                        e =>
                        new CourseListItem
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Students = e.Students,
                        });
                return query.ToArray();
            }
        }
        public CourseDetail GetCourseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Courses
                    .Single(e => e.Id == id);
                return
                    new CourseDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Instructor = entity.Instructor,
                        InstructorId = entity.InstructorId,
                        InstructorGuid = Guid.Parse(entity.InstructorId),
                        Students = entity.Students
                    };
                      

            }
        }
    }
}
