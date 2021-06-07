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
                    CourseName = c.CourseName,
                    Instructor = c.Instructor
                });
            var model = new CourseIndexModel
            {
                CourseIndexList = courses
            };
            return View(model);
        }
        // Similar method to Index(), but to provide for filtered CourseIndexModel view by Instructor UserId.  
        public IActionResult MyCourses(string userId)
        {
            var myCourses = _courseService.GetByInstructor(userId)
                .Select(c => new CourseListItem
                {
                    Id = c.Id,
                    Instructor = c.Instructor,
                    CourseName = c.CourseName,
                });
            var model = new CourseIndexModel
            {
                CourseIndexList = myCourses
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
