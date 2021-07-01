using SchoolBoard.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Interfaces
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAllUsers();

        Task SetProfileImage(string id, Uri uri);
        // TODO add Tasks for administrative functions here.

        Task CreateInstructorAccount(string id, string name, IEnumerable<Course> courses);
        Task CreateCourse(int id, string name, IEnumerable<Student> students, ApplicationUser instructor);
        Task CreateStudent(int id, string name, IEnumerable<Course> courses);
        Task UpdateCourse(int id, string name, IEnumerable<Student> students, ApplicationUser instructor);
        Task UpdateStudent(int id, string name, IEnumerable<Course> courses);
    }
}
