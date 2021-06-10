using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Interfaces;
using SchoolBoard.Models.PostReplyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBoard.MVC.Controllers
{
    public class ReplyController : Controller
    {
        private readonly IPost _postService;
        private readonly UserManager<ApplicationUser> _userManager;
        public ReplyController(IPost postService)
        {
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
                AuthorName = user.Name,
                StudentName = post.Student.Name,
                Created = DateTime.Now,
                StudentImgUrl = post.Student.ImgUrl
            };
            return View(model);
        }
    }
}
