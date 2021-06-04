using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SchoolBoard.Data.DataModels;

namespace SchoolBoard.Data.SeedData
{
    // This class can be called to seed default values via ApplicationDbContext - typically from Startup.cs - It also creates initial roles and users.
    public static class DbInitialize
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                // instantiating the DbContext (vs 'using' statement newing up var context - in v1.0)
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                var _userManager = 
                    serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();
                var _roleManager = 
                    serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
               
                // If the admin, instructor, and student role is not yet created, create the roles.
                if (!_roleManager.RoleExistsAsync("Administrator").Result)
                {
                    var role = _roleManager.CreateAsync(
                        new IdentityRole { Name = "Administrator" }).Result;
                }

                if (!_roleManager.RoleExistsAsync("Instructor").Result)
                {
                    var role = _roleManager.CreateAsync(
                        new IdentityRole { Name = "Instructor" }).Result;
                }

                if (!_roleManager.RoleExistsAsync("Student").Result)
                {
                    var role = _roleManager.CreateAsync(
                        new IdentityRole { Name = "Student" }).Result;
                }


                // check for Administrator Account, if null, seed ApplicationUsers with single admin entry
                var adminUser = context.ApplicationUsers
                    .Where(a => a.Name == "Admin").FirstOrDefault();
                if (adminUser == null)
                {
                    adminUser = new DataModels.ApplicationUser()
                    {
                        Name = "Admin",
                        Email = "admin@test.com",
                        EmailConfirmed = true,
                        UserName = "admin@test.com",
                        Courses = null,

                    };
                    var userResult = _userManager.CreateAsync(adminUser, "Test1!").Result;
                    _userManager.AddToRoleAsync(adminUser, "Administrator");
                    context.SaveChanges();
                }

              
                
              
                // demo students
                var student1 = new Student() { Name = "Student 1", ImgUrl = "#", GPA = 2.5, SatisfactoryPerformance = false };
                var student2 = new Student() { Name = "Student 2", ImgUrl = "#", GPA = 3.5, SatisfactoryPerformance = true };

                // if context has no students, add demos
                if (!context.Students.Any())
                {
                   
                    context.Students.Add(student1);
                    context.Students.Add(student2);
                    context.SaveChanges();
                }

                // If context has no courses, add demo.

                var computerScience = new Course() { CourseName = "Computer Science", Instructor = adminUser, Students = new List<Student>() { student1, student2 } };
                if (!context.Courses.Any())
                {
                   
                    context.Courses.Add(computerScience);
                    context.SaveChanges();
                   
                }

              














                

            }
        }
    }
}
