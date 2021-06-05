using Microsoft.EntityFrameworkCore;
using SchoolBoard.Data;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Services
{
    public class StudentService : IStudent
    {
        private readonly ApplicationDbContext _context;
        private readonly ICourse _courseService;
        public StudentService(ApplicationDbContext context, ICourse courseService)
        {
            _context = context;
            _courseService = courseService;
        }

        public Task Create(Student student)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int studentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetActiveInstructors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students
                .Include(s => s.Posts);
        }

        public IEnumerable<Student> GetByCourse(int id)
        {
            var course = _courseService.GetById(id);
            var students = course.Students;
            return students;
        }

        public Student GetById(int id)
        {
            var student = _context.Students
                .Where(s => s.Id == id)
                    .Include(s=>s.Posts)
                        .ThenInclude(p=>p.Replies)
                            .ThenInclude(r=>r.Instructor)
                    .Include(s=>s.Posts)
                        .ThenInclude(p=>p.Instructor)
                .FirstOrDefault();
            return student;
        }

        public Task UpdateStudent(int studentId, string Name, bool satisfactoryPerformance, double GPA)
        {
            throw new NotImplementedException();
        }
    }
}
