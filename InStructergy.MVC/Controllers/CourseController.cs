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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseService(userId);
            var model = service.GetCourses();
            return View(model);
   
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseService(userId);
            service.CreateCourse(model);
            return RedirectToAction("Index");
            
        }
    }
}
