using SchoolBoard.Data.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolBoard.Interfaces
{
    public interface ICourse
    {
        
        Course GetById(int id);
        IEnumerable<Course> GetByInstructor(string userId);
        IEnumerable<Course> GetAll();

         
        Task Create(Course course);
        Task Delete(int courseId);
        Task UpdateCourse(int courseId, string Name, IEnumerable<Student> students, ApplicationUser instructor);
    }
}