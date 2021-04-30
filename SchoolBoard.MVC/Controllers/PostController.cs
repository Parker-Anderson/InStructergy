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

        public ActionResult Create(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var studentService = new StudentService(userId);
            var student = studentService.GetStudentById(id);
            var model = new NewPostModel
            {
                InstructorName = User.Identity.Name,
                StudentName = student.Name
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(PostCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreatePostService();
            service.CreatePost(model);
            return View(model);
        }            
                //**** --> CREATE NEW MODEL FOR 'new Post' where Student = student, not StudentDetail.  Maybe ignore PostCreate (in vid '09' @ 4:27) --> then once passed into controller method, @ 7:00 begin httppost method. --> iot allow user post creation from view. 
                //will have to redo above 10 lines or so./ 



        
        public ActionResult Details(int id)
        {
            var service = CreatePostService();
            var model = service.GetPostById(id);
            return View(model);
        }
    }

}