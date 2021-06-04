using Microsoft.AspNetCore.Mvc;
using SchoolBoard.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBoard.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _studentService;
        public StudentController(IStudent studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
