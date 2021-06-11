using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using SchoolBoard.Models.CourseModels;
using SchoolBoard.Models.HomeModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBoard.MVC.Controllers
{
    public class HomeHelperController : Controller
    {
        public HomeHelperController()
        {
        }

        public IActionResult Index(HomeIndexModel homeModel, CourseIndexModel coursesModel, RegisterModel registerModel)
        {
            var model = new SchoolBoard.Models.HelperModels.HomeShared
            {
                HomeIndexModel = homeModel,
                MyCoursesModel = coursesModel,
                RegisterModel = registerModel
            };
            return View(model);
        }
    }
}
