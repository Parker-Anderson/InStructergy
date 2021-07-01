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
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task CreateCourse(int id, string name, IEnumerable<Student> students, ApplicationUser instructor)
        {
            throw new NotImplementedException();
        }

        public Task CreateInstructorAccount(string id, string name, IEnumerable<Course> courses)
        {
            throw new NotImplementedException();
        }

        public Task CreateStudent(int id, string name, IEnumerable<Course> courses)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _context.ApplicationUsers;
        }

        public ApplicationUser GetById(string id)
        {
            return GetAllUsers().FirstOrDefault(u => u.Id == id);
                
        }

        public async Task SetProfileImage(string id, Uri uri)
        {
            var user = GetById(id);
            user.ImageUrl = uri.AbsoluteUri;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public Task UpdateCourse(int id, string name, IEnumerable<Student> students, ApplicationUser instructor)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudent(int id, string name, IEnumerable<Course> courses)
        {
            throw new NotImplementedException();
        }
    }
}
