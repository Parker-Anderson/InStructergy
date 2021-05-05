using SchoolBoard.Data;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Models.CourseModels;
using SchoolBoard.Models.StudentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Services
{
    public class CourseService
    {
        private readonly Guid _userId;

        public CourseService(Guid userId)
        {
            _userId = userId;
        }

        public ICollection<CourseListItem> GetCourses()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                    .Courses
                    .Include("Students")
                    .Select(e => new CourseListItem
                    {
                        Id = e.Id,
                        CourseName = e.CourseName,
                        Instructor = e.Instructor,
                        Students = e.Students,
                    });
                return query.ToArray();
            }
        }

        public ICollection<CourseListItem> GetCoursesByUser()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                    .Courses
                    .Include("Students")
                    .Where(c => c.Instructor.Id == _userId.ToString())
                    .Select(e => new CourseListItem
                    {
                        Id = e.Id,
                        CourseName = e.CourseName,
                        Instructor = e.Instructor,
                        Students = e.Students,
                    });
                return query.ToArray();
            }
        }
        // --> Can now assign list of courses based on logged in Instructor.  Next will be to add more teachers and courses and wrap index course listings into href links to Course Detail page
        public CourseDetail GetCourseById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Courses.Include("Students")
                    .Single(c => c.Id == id);

                return new CourseDetail
                {
                    Id = entity.Id,
                    CourseName = entity.CourseName,
                    Students = entity.Students
                };

            }
        }

        public StudentDetail GetStudentById(int id)
        {
            using (var context = new ApplicationDbContext())
            {

                var entity =
                    context
                    .Students
                    .Include("Posts")
                    .SingleOrDefault(s => s.Id == id);
                return new StudentDetail
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Posts = entity.Posts,
                    GPA = entity.GPA

                };
            }
        }
        public StudentDetail GetStudentByName(string name)
        {
            using (var context = new ApplicationDbContext())
            {

                var entity =
                    context
                    .Students
                    .Include("Posts")
                    .Where(s => s.Name == name)
                    .SingleOrDefault(s => s.Name == name);
                return new StudentDetail
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Posts = entity.Posts,
                    GPA = entity.GPA

                };
            }
        }

    }
}

