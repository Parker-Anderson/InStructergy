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
    public class DbInitialize
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

                // If Users (not ApplicationUser(app-specific)) is empty, new demo User is seeded.
                if(!context.Users.Any(u => u.UserName == "first@test.com"))
                {
                    var user = new IdentityUser()
                    {
                        UserName = "first@test.com",
                        Email = "first@test.com",
                        EmailConfirmed = true,
                    };
                    var userResult = _userManager.CreateAsync(user, "Test1!").Result;
                }
                
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
                if(adminUser == null)
                {
                    adminUser = new DataModels.ApplicationUser()
                    {
                        Name = "Admin",
                        Email = "admin@test.com",
                        UserName = "admin@test.com",
                        Courses = null,
                       
                    };
                    context.SaveChanges();
                }

                // declare and assign two demo Courses.
                var computerScience = new Course() { CourseName = "Computer Science", Instructor = adminUser, Students = new List<Student>() };
                var math = new Course() { CourseName = "Math", Instructor = adminUser, Students = new List<Student>() };

                // check if context.Courses contains values, if null add demo courses.
                var courses = context.Courses.ToList();
                if(courses == null)
                {
                    courses.Add(computerScience);
                    courses.Add(math);
                }

            }
        }
    }
}
