using Microsoft.AspNetCore.Mvc;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Interfaces;
using SchoolBoard.Models.PostModels;
using SchoolBoard.Models.SearchModels;
using SchoolBoard.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBoard.MVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPost _postService;
        public SearchController(IPost postService)
        {
            _postService = postService;
        }
        public IActionResult Results(string searchQuery)
        {
            var posts = _postService.GetSearchedPosts(searchQuery);
            //  simple fallback for empty search.
            var noSearch = (!string.IsNullOrEmpty(searchQuery) && !posts.Any());
            var postsList = posts.Select(p => new PostListItem
            {
                Id = p.Id,
                Title = p.Title,
                Body = p.Body,
                Created = p.Created,
                Author = p.Instructor,
                StudentId = p.StudentId,
                Student = BuildStudentListItem(p),
                RepliesCount = p.Replies.Count(),
                StudentName = p.Student.Name
            });
            var model = new SearchResultModel
            {
                Posts = postsList,
                SearchQuery = searchQuery,
                EmptySearchField = noSearch
            };
            return View(model);
        }
        // enables conversion from posts.Student to StudentListItem.
        private StudentsListItem BuildStudentListItem(Post p)
        {
            var student = p.Student;
            return new StudentsListItem
            {
                Id = student.Id,
                ImgUrl = student.ImgUrl,
                Name = student.Name,
            };
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Results", new { searchQuery });
        }
    }
}
