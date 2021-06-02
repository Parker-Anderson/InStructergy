using Microsoft.AspNetCore.Identity;
using SchoolBoard.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Data.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
