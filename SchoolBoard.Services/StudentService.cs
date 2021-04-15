using SchoolBoard.Data;
using SchoolBoard.Data.EntityModels;
using SchoolBoard.Models.StudentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Services
{
    public class StudentService
    {

        private readonly Guid _userId = new Guid();
            public StudentService(Guid userId)
            {
            _userId = userId;
            }
            public bool CreateStudent(StudentCreate model)
            {
                var entity =
                    new Student()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Files = model.Files,
                        Courses = model.Courses,
                        InstructorId = _userId,
                        Instructors = model.Instructors,
                        GradePointAverage = model.GradePointAverage
                    };
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Students.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
            public IEnumerable<StudentListItem> GetStudents()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                        .Students
                        .Select(
                            e =>
                            new StudentListItem
                            {
                                Id = e.Id,
                                Name = e.Name,
                                Files = e.Files,
                                Courses = e.Courses,
                                InstructorId = _userId,
                                Instructors = e.Instructors,
                                GradePointAverage = e.GradePointAverage
                            });
                    return query.ToArray();
                }
            }
            public StudentDetail GetStudentById(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Students
                        .Single(e => e.Id == id);
                    return
                        new StudentDetail
                        {
                            Id = entity.Id,
                            Name = entity.Name,
                            Files = entity.Files,
                            Courses = entity.Courses,
                            InstructorId = _userId,
                            Instructors = entity.Instructors,
                            GradePointAverage = entity.GradePointAverage
                        };


                }
            }
            public bool UpdateStudent(StudentEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Students
                        .Single(e => e.Id == model.Id && e.InstructorId == _userId);

                    return ctx.SaveChanges() == 1;
                }

            }
            public bool DeleteStudent(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx.Students
                        .Single(e => e.Id == id && e.InstructorId == _userId);
                    ctx.Students.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
        }

    }
