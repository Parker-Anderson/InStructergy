using Microsoft.AspNetCore.Identity;
using SchoolBoard.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Data.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        //App-specific additional definitions for the User 
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public bool IsActive { get; set; }

    }
}
