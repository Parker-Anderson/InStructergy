using Microsoft.AspNetCore.Http;
using SchoolBoard.Data.DataModels;
using System.Collections.Generic;

namespace SchoolBoard.Models.UserModels
{
    public class UserProfileModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string ImgUrl { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IFormFile ImgUpload { get; set; }
        public bool IsAdmin { get; set; }

    }
}
