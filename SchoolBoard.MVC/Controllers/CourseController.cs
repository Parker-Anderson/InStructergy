using Microsoft.AspNetCore.Mvc;
using SchoolBoard.Interfaces;
using SchoolBoard.Models.CourseModels;
using SchoolBoard.Models.Student;
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


        public IActionResult Detail(int id)
        {
            var course = _courseService.GetById(id);
            var students = course.Students
                .Select(s => new StudentsListItem
                {
                    Id = s.Id,
                    Name = s.Name
                });

            var model = new CourseStudentIndexModel
            {
                Students = students
            };
            return View(model);
        }
    }
}
