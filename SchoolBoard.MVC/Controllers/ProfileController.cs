using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolBoard.Data.DataModels;
using SchoolBoard.Interfaces;
using SchoolBoard.Models.UserModels;
using System.Threading.Tasks;

namespace SchoolBoard.MVC.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        //Upload Service used to enable uploading of profile images to cloud storage
        private readonly IUpload _uploadService;
        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IUpload uploadService)
        {
            _userManager = userManager;
            _userService = userService;
            _uploadService = uploadService;
        }
        public IActionResult Detail(string id)
        {
            var user = _userService.GetById(id);
                
            var userRoles = _userManager.GetRolesAsync(user).Result;
            var model = new UserProfileModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Courses = user.Courses,
                ImgUrl = user.ImageUrl,
                IsAdmin = userRoles.Contains("Administrator")

            };
            return View(model);
        }
        //
        //[HttpPost]
        //public async Task<IActionResult> UploadFile(IFormFile file)
        //{
          //  var userId = _userManager.GetUserId(User);
            //Connect to Azure Object storage
            //Get BLOB Container
            //Parse the Content Disposition response header
            //Get filename
            //Get reference to a Block BLOB
            //on that Block BLOB, file uploaded to cloud

            //Attach the file to post, profileimg, reply or other table.
        //}
    }
}
