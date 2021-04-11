using InStructergy.Data;
using InStructergy.Data.EntityModels;
using InStructergy.Models;
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
            _userId = userId;
        }

        public bool CreateCourse(CourseCreate model)
        {
            var entity =
                new Course()
                {
                    Name = model.Name,
                    Students = model.Students
                };
            using (var ctx = new ApplicationDbContext())
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
                    //.Where(e => e.InstructorId == _userId)
                    .Select(
                        e =>
                        new CourseListItem
                        {
                            Id = e.Id,
                            Name = e.Name,

                        }
                        );
                return query.ToArray();
            }
        }
    }
}
