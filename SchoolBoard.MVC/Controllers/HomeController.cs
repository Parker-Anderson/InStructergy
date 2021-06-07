using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBoard.Interfaces;
using SchoolBoard.Models.HomeModels;
using SchoolBoard.MVC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Linq;
using SchoolBoard.Models.PostModels;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Models.Student;

namespace SchoolBoard.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPost _postService;
        public HomeController(IPost postService, UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _postService = postService;
            _logger = logger;
        }
       

    

        public IActionResult Index()
        {
            var model = BuildHomeIndexModel();
            return View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var recentPosts = _postService.GetRecent(userId, 5);
            var posts = recentPosts.Select(p => new PostListItem
            {
                Id = p.Id,
                Title = p.Title,
                Author = p.Instructor,
                AuthorId = p.Instructor.Id,
                Body = p.Body,
                Student = BuildStudentForPost(p),
                StudentId = p.StudentId,
                Created = p.Created

            });
            return new HomeIndexModel
            {
                RecentPosts = posts,
                SearchQuery = ""
            };
        }

        private StudentsListItem BuildStudentForPost(Post post)
        {
            var student = post.Student;
            return new StudentsListItem
            {
                Name = student.Name,
                ImgUrl = student.ImgUrl,
                Id = student.Id
            };
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

