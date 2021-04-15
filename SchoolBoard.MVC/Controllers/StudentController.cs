using SchoolBoard.Models.StudentModels;
using SchoolBoard.Services;
using Microsoft.AspNet.Identity;
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
            var service = CreateStudentService();
            var model = service.GetStudents();
            return View(model);
            
        }
        private StudentService CreateStudentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StudentService(userId);
            return service;
        }

        //GET: Create 
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
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var svc = CreateStudentService();
            var model = svc.GetStudentById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateStudentService();
            var detail = service.GetStudentById(id);
            var model =
                new StudentEdit
                {
                    Name = detail.Name,
                    Files = detail.Files,
                    GradePointAverage = detail.GradePointAverage,
                    Courses = detail.Courses

                };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, StudentEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateStudentService();
            if (service.UpdateStudent(model))
            {
                TempData["SaveResult"] = "Student Saved.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Student could not be Created.");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateStudentService();
            var model = svc.GetStudentById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult StudentDelete(int id)
        {
            var service = CreateStudentService();
            service.DeleteStudent(id);
            TempData["SaveResult"] = "Student Deleted";
            return RedirectToAction("Index");
        }

    }
}