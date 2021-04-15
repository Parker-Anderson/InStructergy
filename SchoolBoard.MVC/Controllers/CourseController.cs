using SchoolBoard.Models.CourseModels;
using SchoolBoard.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBoard.MVC.Controllers
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

        //GET: Create 
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
        public ActionResult Details(int id)
        {
            var svc = CreateCourseService();
            var model = svc.GetCourseById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateCourseService();
            var detail = service.GetCourseById(id);
            var model =
                new CourseEdit
                {
                    Id = detail.Id,
                    Name = detail.Name,
                    Students = detail.Students,
                };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, CourseEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCourseService();
            if (service.UpdateCourse(model))
            {
                TempData["SaveResult"] = "Course Saved.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Course could not be Created.");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateCourseService();
            var model = svc.GetCourseById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCourse(int id)
        {
            var service = CreateCourseService();
            service.DeleteCourse(id);
            TempData["SaveResult"] = "Course Deleted";
            return RedirectToAction("Index");
        }


    }
}