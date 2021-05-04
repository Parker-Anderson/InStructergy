using Microsoft.AspNet.Identity;
using SchoolBoard.MVC.Controllers;
using SchoolBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBoard.Web.Controllers
{
    public class StudentController : ApplicationBaseController
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        //--> So far - Can get course list based on logged in user (course/index), can view student list within course (course/details/id), can access detail page (getbyid) for student [with ability to list out posts IF any]. To do - wrap necessary view page table items as href links.
        //-->cont'd : seed posts necessary? build out post view models and controller. Don't forget to look back at getting home page to display user.name and not username.
        public ActionResult Details(int id)
        {
            var service = new CourseService(Guid.Parse(User.Identity.GetUserId()));
            var model = service.GetStudentById(id);
            return View(model);
        }
    }
}