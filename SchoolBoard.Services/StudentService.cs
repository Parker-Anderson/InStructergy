using Microsoft.EntityFrameworkCore;
using SchoolBoard.Data;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Services
{
    public class StudentService : IStudent
    {
        private readonly ApplicationDbContext _context;
        public StudentService(ApplicationDbContext context)
        {
            _context = context;
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

        public IEnumerable<Student> GetByCourse()
        {
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudent(int studentId, string Name, bool satisfactoryPerformance, double GPA)
        {
            throw new NotImplementedException();
        }
    }
}
