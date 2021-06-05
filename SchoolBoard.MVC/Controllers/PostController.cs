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
        
        public PostController(IPost service)
        {
            _postService = service;
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
