using Microsoft.AspNetCore.Mvc;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Interfaces;
using SchoolBoard.Models.PostModels;
using SchoolBoard.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBoard.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _studentService;

        public StudentController(IStudent studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            var students = _studentService.GetAll()
                .Select(student => new StudentsListItem { Id = student.Id, Name = student.Name });
            var model = new CourseStudentIndexModel
            {
                Students = students
            };
            return View(model);
        }


        public IActionResult Detail(int id)
        {

            var student = _studentService.GetById(id);
            var posts = student.Posts;

            var postList = posts.Select(p => new PostListItem
            {
                Id = p.Id,
                Author = p.Instructor,
                AuthorId = p.Instructor.Id,
                Title = p.Title,
                Body = p.Body,
                Created = p.Created,
                StudentId = p.StudentId,
                StudentName = p.Student.Name,
                Student = BuildStudentListItem(p),
                RepliesCount = p.Replies.Count()
            });
            var model = new StudentDetailViewModel
            {
                Posts = postList,
                Student = BuildStudentListItem(student)
            };
            return View(model);
        }

        private StudentsListItem BuildStudentListItem(Post p)
        {
            var student = p.Student;
            return BuildStudentListItem(student);
        }
        private StudentsListItem BuildStudentListItem(Student s)
        {
            return new StudentsListItem
            {
                Id = s.Id,
                Name = s.Name,
                ImgUrl = s.ImgUrl
            };

        }
    }
}
