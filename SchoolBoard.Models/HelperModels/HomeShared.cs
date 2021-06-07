using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Models.HelperModels
{
    public class HomeShared
    {
        public HomeModels.HomeIndexModel HomeIndexModel { get; set; }
        public  RegisterModel RegisterModel { get; set; }
        public CourseModels.CourseIndexModel MyCoursesModel { get; set; }
    }
}
