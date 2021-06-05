using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Interfaces;
using SchoolBoard.Models.PostModels;
using SchoolBoard.Models.PostReplyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBoard.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IStudent _studentService;
        private static UserManager<IdentityUser> _userManager;
        
        public PostController(IPost postService, IStudent studentService, UserManager<IdentityUser> userManager)
        {
            _postService = postService;
            _studentService = studentService;
            _userManager = userManager;
        }
        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            var replies = BuildReplies(post.Replies);
            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.Instructor.Id,
                AuthorName = post.Instructor.Name,
                ImgUrl = post.Instructor.ImageUrl,
                Body = post.Body,
                Replies = replies,
                Created = post.Created
            };
            return View(model);
        }
        //id parameter in Create(int id) will be the StudentId, this method directs to the create viewmodel to accept input.
        public IActionResult Create(int id)
        {
            var student = _studentService.GetById(id);
            var model = new CreatePostModel
            {
                StudentName = student.Name,
                StudentId = student.Id,
                AuthorName = User.Identity.Name
            };
            return View(model);
        }
        // Add new Post to the database
        [HttpPost]
        public async Task<IActionResult> AddPost(CreatePostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var post = BuildPostEntity(model, user);

            _postService.Add(post).Wait(); // .Wait() blocks current thread until the Task is completed.
            return RedirectToAction("Detail", "Student", new { id = post.Student.Id }); // need to new up the route-id object to avoid "Sequence contains no value" exception.
        }


        // This private method 'reverses' the flow of data - that is, it passes the accepted input data from the ViewModel back to the Data Model to be INSERTed into the Db.
        private Post BuildPostEntity(CreatePostModel model, IdentityUser user)
        {
            var student = _studentService.GetById(model.StudentId);
            
            return new Post
            {
                Title = model.Title,
                Body = model.Body,
                Created = DateTime.Now,
                Instructor = (ApplicationUser)user,
                Student = student
            };
        }

        // Convert the IEnumerable<PostReply> (post.Replies) to IEnumerable<ReplyModel> 
        private IEnumerable<ReplyModel> BuildReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(r => new ReplyModel
            {
                Id = r.Id,
                AuthorId = r.Instructor.Id,
                AuthorName = r.Instructor.Name,
                ImgUrl = r.Instructor.ImageUrl,
                Body = r.Body,
                Created = r.Created,
                PostId = r.Post.Id
            });
        }
    }
}
