using Microsoft.AspNet.Identity;
using SchoolBoard.Data;
using SchoolBoard.Data.DomainModels;
using SchoolBoard.Models.PostModels;
using SchoolBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolBoard.MVC.Controllers
{
    public class PostController : Controller
    {
        private static UserManager<ApplicationUser> _userManager;
        private readonly PostService _postService;
        private readonly StudentService _studentService;
        
        
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
        public async Task<ActionResult> CreatePost(NewPostModel model)
        {
              
              var userId = User.Identity.GetUserId();
              var user = await _userManager.FindByIdAsync(userId);
              var post = BuildPost(model, user);

            await _postService.Add(post);

            return RedirectToAction("Index", "Post", post.Id);
            //-->> after creating Add method in PostService

              
        }

        private Post BuildPost(NewPostModel model, ApplicationUser user)
        {
            var student = _studentService.GetStudentEntityById(model.StudentId);
            return new Post
            {
                Instructor = user,
                Title = model.Title,
                Body = model.Body,
                Created = DateTime.Now,
                Student = student
            };
        }

        //**** --> CREATE NEW MODEL FOR 'new Post' where Student = student, not StudentDetail.  Maybe ignore PostCreate 




        public ActionResult Details(int id)
        {
            var service = CreatePostService();
            var model = service.GetPostById(id);
            return View(model);
        }
    }

}