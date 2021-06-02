using Microsoft.AspNetCore.Mvc;
using SchoolBoard.Interfaces;
using SchoolBoard.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBoard.MVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourse _courseService;
        public CourseController(ICourse service)
        {
            _courseService = service;
        }

        public IActionResult Index()
        {
            var courses = _courseService.GetAll()
                .Select(c => new CourseListItem
                {
                    Id = c.Id,
                    CourseName = c.CourseName
                });
            var model = new CourseIndexModel
            {
                CourseIndexList = courses
            };
            return View(model);
        }
    }
}
