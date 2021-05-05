using Microsoft.AspNet.Identity;
using SchoolBoard.Models.CourseModels;
using SchoolBoard.MVC.Controllers;
using SchoolBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBoard.Web.Controllers
{
    public class CourseController : ApplicationBaseController
    {
        // GET: Course
        public ActionResult Index()
        {
            var _courseService = new CourseService(Guid.Parse(User.Identity.GetUserId()));
            var model = _courseService.GetCourses().Select(c => new CourseListItem
            {
                Id = c.Id,
                Instructor = c.Instructor,
                Students = c.Students,
                CourseName = c.CourseName
            });

            return View(model);
        }
        public ActionResult MyCourses()
        {
            var _courseService = new CourseService(Guid.Parse(User.Identity.GetUserId()));
            var model = _courseService.GetCoursesByUser().Select(c => new CourseListItem
            {
                Id = c.Id,
                Instructor = c.Instructor,
                Students = c.Students,
                CourseName = c.CourseName,
            });
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var service = new CourseService(Guid.Parse(User.Identity.GetUserId()));
            var model = service.GetCourseById(id);
            return View(model);
        }
    }
}