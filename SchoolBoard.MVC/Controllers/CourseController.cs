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
            var _courseService = new CourseService(Guid.Parse(User.Identity.GetUserId()));
            var _studentService = new StudentService(Guid.Parse(User.Identity.GetUserId()));
            var course = _courseService.GetCourseById(id);
            var students = course.Students;
            var studentsList = students.Select(student => new StudentListItem
            {
                Id = student.Id,
                Name = student.Name,

            });
            var model = new CourseStudentModel
            {
                Students = studentsList,
                Course = new CourseListItem
                {
                    Id = course.Id,
                    Name = course.Name,
                    Instructor = course.Instructor,
                }
            };
            return View(model);
             
        }
        private CourseListItem BuildCourseListItem(Course course)
        {
            return new CourseListItem
            {
                Id = course.Id,
                Name = course.Name,
                Instructor = course.Instructor
            };
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
        private CourseListItem courseStudentListModel(Student student, int id)
        {
            var course = student.Courses.Single(c => c.Id == id);
            return new CourseListItem
            {
                Id = course.Id,
                Name = course.Name,

            };
        }


    }
}