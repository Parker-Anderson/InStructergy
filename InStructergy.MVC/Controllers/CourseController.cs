using InStructergy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InStructergy.MVC.Controllers
{
    [Authorize(Roles = "Admin,Instructor")]
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            var model = new CourseListItem[0];
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseCreate model)
        {
            if (!ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
