using Microsoft.AspNet.Identity;
using SchoolBoard.Data.DomainModels;
using SchoolBoard.Models.CourseModels;
using SchoolBoard.Models.StudentModels;
using SchoolBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBoard.MVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly Guid _userId;
        private readonly CourseService _courseService;
        private readonly StudentService _studentService;
        
        [Authorize]
        // GET: CourseModels
        public ActionResult Index()
        {
            var _courseService = new CourseService(Guid.Parse(User.Identity.GetUserId()));
            var courses = _courseService.GetCourses().Select(e => new CourseListItem
            {
                Id = e.Id,
                Name = e.Name,
                Instructor = e.Instructor
            });
            var model = new CourseIndexModel()
            {
                Courses = courses
            };
            return View(model);

        }
        public ActionResult Student(int id)
        {
            var course = _courseService.GetCourseById(id);
            var students = _studentService.GetStudentsByCourse(id);
            var studentListItems = students.Select(student => new StudentListItem
            {
                Id = student.Id,
                Name = student.Name,
                InstructorGuid = student.InstructorGuid, 
                
            });
            return View();
        }
        private CourseListItem BuildCourseListItem(Student student)
        {
            throw new NotImplementedException();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = new CourseService(Guid.Parse(User.Identity.GetUserId()));
            service.CreateCourse(model);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var service = new CourseService(Guid.Parse(User.Identity.GetUserId()));
            var model = service.GetCourseById(id);
            return View(model);
        }

    }
}