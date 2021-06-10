using Microsoft.EntityFrameworkCore;
using SchoolBoard.Data;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace SchoolBoard.Services
{
    public class CourseService : ICourse
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        public CourseService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task Create(Course course)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses
                .Include(c => c.Students)
                .Include(c=>c.Instructor);
        }

        public Course GetById(int id)
        {
            var course = _context.Courses
                 .Where(c => c.Id == id)
                      .Include(c => c.Instructor)
                      .Include(c => c.Students)
                            .ThenInclude(s => s.Posts)
                                .ThenInclude(p => p.Instructor)
                      .Include(c => c.Students)
                            .ThenInclude(s => s.Posts)
                                .ThenInclude(p => p.Replies)
                                    .ThenInclude(r => r.Instructor)
                  .FirstOrDefault();
            return course;

        }
        // Reason this method was originally giving null ref exception was because of Lazy Loading, must .Include() the Instructor navigation property.
        public IEnumerable<Course> GetByInstructor(string userId)
        {
            // For .NET Core => User.Identity.GetUserId() does not work.
            userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            return _context.Courses
                .Include(c=>c.Students)
                .Include(c=>c.Instructor)
                .Where(c => c.Instructor.Id == userId);
        }

        public Task UpdateCourse(int courseId, string Name, IEnumerable<Student> students, ApplicationUser instructor)
        {
            throw new NotImplementedException();
        }
    }
}
