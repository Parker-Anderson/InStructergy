using InStructergy.Models;
using InStructergy.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InStructergy.MVC.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            var service = CreateCourseService();
            var model = service.GetCourses();
            return View(model);

        }

        private CourseService CreateCourseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseService(userId);
            return service;
        }

        //GET
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
            var service = CreateCourseService();
            service.CreateCourse(model);
            return RedirectToAction("Index");
            
        }
    }
}
