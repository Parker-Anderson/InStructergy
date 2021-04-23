using Microsoft.AspNet.Identity;
using SchoolBoard.Models.PostModels;
using SchoolBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolBoard.MVC.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            var service = CreatePostService();
            var model = service.GetPosts();
            return View(model);
        }

        private PostService CreatePostService()
        {
            var userId = User.Identity.GetUserId();
            PostService service = new PostService(Guid.Parse(userId));
            return service;
        }

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
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var service = CreatePostService();
            var model = service.GetPostById(id);
            return View(model);
        }
    }

}