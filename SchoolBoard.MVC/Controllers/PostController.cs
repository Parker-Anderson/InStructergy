using SchoolBoard.Models.PostModels;
using SchoolBoard.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBoard.MVC.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Index()
        {
            var service = CreatePostService();
            var model = service.GetPosts();
            return View(model);

        }

        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            return service;
        }

        //GET: Create 
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreatePostService();
            service.CreatePost(model);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreatePostService();
            var detail = service.GetPostById(id);
            var model =
                new PostEdit
                {

                };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, PostEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreatePostService();
            if (service.UpdatePost(model))
            {
                TempData["SaveResult"] = "Post Saved.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Post could not be Created.");
            return View();
        }
        public ActionResult Delete(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePostService();
            service.DeletePost(id);
            TempData["SaveResult"] = "Post Deleted";
            return RedirectToAction("Index");
        }


    }
}
