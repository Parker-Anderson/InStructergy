using Microsoft.AspNet.Identity;
using SchoolBoard.Models.PostModels;
using SchoolBoard.Models.StudentModels;
using SchoolBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBoard.MVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            StudentService service = new StudentService(Guid.Parse(userId));
            var model = service.GetStudents();
            return View(model);
        }


        private StudentService CreateStudentService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StudentService(userId);
            return service;
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateStudentService();
            service.CreateStudent(model);
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var service = new StudentService(Guid.Parse(User.Identity.GetUserId()));
            var model = service.GetStudentById(id);
            var posts = model.Posts;
            var postList = posts.Select(post => new PostListItem
            {
                Id = post.Id,
                InstructorId = post.InstructorId,
                Title = post.Title,
                Body = post.Body,
                Created = post.Created,
                Student = post.Student,
            });
      
            return View(model);
        }

    }
}