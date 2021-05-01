using SchoolBoard.Data;
using SchoolBoard.Data.DomainModels;
using SchoolBoard.Models.CourseModels;
using SchoolBoard.Models.StudentModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Services
{
    public class StudentService
    {
        private readonly Guid _instructorId;

        public StudentService(Guid userId)
        {

            _instructorId = userId;
        }
        public bool CreateStudent(StudentCreate model)
        {
            var entity =
                new Student()
                {
                    Name = model.Name,
                    Courses = model.Courses,
                    Instructors = (ICollection<ApplicationUser>)model.Instructors,
                    GradePointAverage = model.GradePointAverage,
                
                };
            using (var context = new ApplicationDbContext())
            {
                context.Students.Add(entity);
                return context.SaveChanges() == 1;
            }

        }
        public IEnumerable<StudentListItem> GetStudents()
        {
            using (var context = new ApplicationDbContext())
            {
                
                var query =
                    context
                    .Students
                    .Select(e => new StudentListItem
                    {

                        Id = e.Id,
                        Name = e.Name,
                    });
                return query.ToArray();
            }
        }
        public IEnumerable<StudentListItem> GetStudentsByCourse(Course course)
        {
            using (var context = new ApplicationDbContext())
            {

                return context.Students.Where(s => s.Courses.Contains(course)).Select(e => new StudentListItem
                {
                    Id = e.Id,
                    Name = e.Name
                }).Include("Posts").Include("Instructor")
                .Include("Replies").Include("Instructor")
                .ToArray();
              
            }
        }
        public Student GetStudentEntityById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Students.Include("Posts")
                    .Single(s => s.Id == id);
                return new Student
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Courses = entity.Courses,
                    Posts = entity.Posts,
                    Instructors = entity.Instructors,
                    GradePointAverage = entity.GradePointAverage

                };

            }
        }

        public StudentDetail GetStudentById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Students.Include("Posts")
                    .Single(e => e.Id == id);
                return
                    new StudentDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Courses = entity.Courses,
                        Posts = entity.Posts,
                        Instructors = entity.Instructors,
                        GradePointAverage = entity.GradePointAverage
                    };
            }
        }
    }
}
