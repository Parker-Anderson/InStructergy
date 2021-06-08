using SchoolBoard.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Interfaces
{
    public interface IStudent
    {
        Student GetById(int id);
        IEnumerable<Student> GetByCourse(int id);
        IEnumerable<Student> GetAll();
        IEnumerable<ApplicationUser> GetActiveInstructors();

        Task Create(Student student);
        Task Delete(int studentId);
        Task UpdateStudent(int studentId, string Name, bool satisfactoryPerformance, double GPA);
        Task SetProfileImage(int id, Uri uri);

    }
}