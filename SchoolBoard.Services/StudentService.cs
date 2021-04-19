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
                    Instructors = model.Instructors,
                    GradePointAverage = model.GradePointAverage,
                    Instructor = model.Instructor,
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
        public IEnumerable<Student> GetStudentsByCourse(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                
                 return context.Courses.Where(c => c.Id == id).First().Students;
              
            }
        }
        public IEnumerable<MyStudentListItem> MyStudents(string id)
        {
            
            using (var db = new ApplicationDbContext())
            {

                var list = db.Students.ToList();
                    ;
                var query = 

                list.Select(l => new MyStudentListItem()
                {
                    Id = l.Id,
                    Name = l.Name,
                });
                return query.ToArray();
            }
        }
        public StudentDetail GetStudentById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Students
                    .Where(s => s.InstructorGuid == _instructorId)
                    .Single(e => e.Id == id);
                return
                    new StudentDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Courses = entity.Courses,
                        Posts = entity.Posts,
                        InstructorGuid = entity.InstructorGuid,
                        Instructors = entity.Instructors,
                        GradePointAverage = entity.GradePointAverage
                    };
            }
        }
    }
}
