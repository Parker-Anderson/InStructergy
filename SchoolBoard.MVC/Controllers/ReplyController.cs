using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Interfaces;
using SchoolBoard.Models.PostReplyModels;
using System;
using System.Threading.Tasks;

namespace SchoolBoard.MVC.Controllers
{
    public class ReplyController : Controller
    {
        private readonly IPost _postService;
        private readonly UserManager<ApplicationUser> _userManager;
        public ReplyController(IPost postService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _postService = postService;
        }
        public async Task<IActionResult> Create(int id)
        {
            var post = _postService.GetById(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new ReplyModel
            {
                PostId = post.Id,
                PostTitle = post.Title,
                PostBody = post.Body,

                AuthorId = user.Id,
                AuthorName = User.Identity.Name,
                ImgUrl = user.ImageUrl,
                StudentName = post.Student.Name,
                StudentId = post.StudentId,
                Created = DateTime.Now,
                StudentImgUrl = post.Student.ImgUrl
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddReply(ReplyModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var reply = BuildReplyEntity(model, user);
            await _postService.AddReply(reply);
            return RedirectToAction("Index", "Post", new { id = model.PostId });
        }

        private PostReply BuildReplyEntity(ReplyModel model, ApplicationUser user)
        {
            var post = _postService.GetById(model.PostId);
            return new PostReply
            {
                Post = post,
                Body = model.Body,
                Created = model.Created,
                Instructor = user
            };
        }
    }

}
