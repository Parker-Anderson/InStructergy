using Microsoft.AspNet.Identity;
using SchoolBoard.Models.PostModels;
using SchoolBoard.MVC.Controllers;
using SchoolBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBoard.Web.Controllers
{
    public class PostController : ApplicationBaseController
    {
        // GET: Post
        public ActionResult Index(int id)
        {
            var service = new PostService(Guid.Parse(User.Identity.GetUserId()));
            var model = service.GetPostsByStudent(id);
            return View(model);
        }

        public ActionResult Details(int id)
        {
            //--> Refactor get post service by extracting method.
            var service = new PostService(Guid.Parse(User.Identity.GetUserId()));
            var model = service.GetPostById(id);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PostCreate model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            var studentService = new CourseService(userId);
            var student = studentService.GetStudentByName(model.Student.Name);
            int? routeId = student.Id;


            service.CreatePost(model);  //--> unable to complete post save because the StudentId is not being captured correctly.
            return RedirectToAction("Index", "Course");
        }
        public ActionResult Edit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            var detail = service.GetPostById(id);
            var model =
                new PostEdit
                {
                    Id = detail.Id,
                    Title = detail.Title,
                    Body = detail.Body

                };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, PostEdit model)
        {
            var service = new PostService(Guid.Parse(User.Identity.GetUserId()));
            if (service.UpdatePost(model))
            {
                return RedirectToAction("Index", "Course");
            }
            ModelState.AddModelError("", "Post could not be updated");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            //--> Refactor get post service by extracting method.
            var service = new PostService(Guid.Parse(User.Identity.GetUserId()));
            var model = service.GetPostById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = new PostService(Guid.Parse(User.Identity.GetUserId()));
            service.DeletePost(id);
            return RedirectToAction("Index", "Course");

        }

    }
}