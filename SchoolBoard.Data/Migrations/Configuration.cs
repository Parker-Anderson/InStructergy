
namespace SchoolBoard.Data.Migrations
{
    using SchoolBoard.Data.DataModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<SchoolBoard.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolBoard.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var bill = new Student { Id = 1, Name = "Bill", GPA = 3.1 };
            var amanda = new Student { Id = 2, Name = "Amanda", GPA = 3.7 };
            var kyle = new Student { Id = 3, Name = "Kyle", GPA = 2.1 };
            var heather = new Student { Id = 4, Name = "Heather", GPA = 2.4};
            var marie = new Student { Id = 5, Name = "Marie", GPA = 3.2 };
            var rachel = new Student { Id = 6, Name = "Rachel", GPA = 1.7 };
            var nicholas = new Student { Id = 7, Name = "Nicholas", GPA = 2.5 };
            var todd = new Student { Id = 8, Name = "Todd", GPA = 2.9 };
            var dakota = new Student { Id = 9, Name = "Dakota", GPA = 4.0 };
            var james = new Student { Id = 10, Name = "James", GPA = 3.8 };
            var pete = new Student { Id = 11, Name = "Pete", GPA = 4.2 };
            var jessica = new Student { Id = 12, Name = "Jessica", GPA = 3.0 };
            var mario = new Student { Id = 13, Name = "Mario", GPA = 2.3 };
            var joey = new Student { Id = 14, Name = "Joey", GPA = 3.6 };
            var luke = new Student { Id = 15, Name = "Luke", GPA = 2.1 };
            var leiah = new Student { Id = 16, Name = "Leiah", GPA = 2.9 };
            context.Students.AddOrUpdate(bill);
            context.Students.AddOrUpdate(amanda);
            context.Students.AddOrUpdate(kyle);
            context.Students.AddOrUpdate(heather);
            context.Students.AddOrUpdate(marie);
            context.Students.AddOrUpdate(rachel);
            context.Students.AddOrUpdate(nicholas);
            context.Students.AddOrUpdate(todd);
            context.Students.AddOrUpdate(dakota);
            context.Students.AddOrUpdate(james);
            context.Students.AddOrUpdate(pete);
            context.Students.AddOrUpdate(jessica);
            context.Students.AddOrUpdate(mario);
            context.Students.AddOrUpdate(joey);
            context.Students.AddOrUpdate(luke);
            context.Students.AddOrUpdate(leiah);


            context.Courses.AddOrUpdate(
                c => c.CourseName,
                new DataModels.Course { CourseName = "Computer Science", Instructor = context.Users.Where(u => u.FullName == "Mrs. Smith").SingleOrDefault(), Students = new List<Student>() { bill, amanda, kyle, heather, james, leiah, mario, dakota, todd } },
                new DataModels.Course { CourseName = "Art", Instructor = context.Users.Where(u => u.FullName == "Mrs. Robinson").SingleOrDefault(), Students = new List<Student>() { bill, amanda, kyle, heather, jessica, joey, luke, leiah, nicholas, rachel, pete } },
                new DataModels.Course { CourseName = "History", Instructor = context.Users.Where(u => u.FullName == "Mrs. Smith").SingleOrDefault(), Students = new List<Student>() { heather, james, leiah, jessica, joey, pete, dakota, bill, amanda } },
                new DataModels.Course { CourseName = "Social Studies", Instructor = context.Users.Where(u => u.FullName == "Mr. Joyce").SingleOrDefault(), Students = new List<Student>() { joey, jessica, pete, mario, todd, amanda, rachel } },
                new DataModels.Course { CourseName = "Physics", Instructor = context.Users.Where(u => u.FullName == "Mrs. Smith").SingleOrDefault(), Students = new List<Student>() { heather, kyle, mario, joey, todd, dakota, bill } },
                new DataModels.Course { CourseName = "Geography", Instructor = context.Users.Where(u => u.FullName == "Mr Joyce").SingleOrDefault(), Students = new List<Student>() { nicholas, rachel, pete, jessica, leiah, luke } });



            //var seedpost1 = new Post { Id = 1, StudentId = 1, InstructorId = context.Users.Where(u=>u.FullName == "Mrs. Smith").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost2 = new Post { Id = 2, StudentId = 2, InstructorId = context.Users.Where(u => u.FullName == "Mrs. Robinson").SingleOrDefault().Id, Title = "First Post",  Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost3 = new Post { Id = 3, StudentId = 3, InstructorId = context.Users.Where(u => u.FullName == "Mr. Jones").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost4 = new Post { Id = 4, StudentId = 4, InstructorId = context.Users.Where(u => u.FullName == "Mr. Joyce").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost5 = new Post { Id = 5, StudentId = 5, InstructorId = context.Users.Where(u => u.FullName == "Mrs. Smith").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost6 = new Post { Id = 6, StudentId = 6, InstructorId = context.Users.Where(u => u.FullName == "Mrs. Robinson").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost7 = new Post { Id = 7, StudentId = 7, InstructorId = context.Users.Where(u => u.FullName == "Mr. Joyce").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost8 = new Post { Id = 8, StudentId = 8, InstructorId = context.Users.Where(u => u.FullName == "Mr. Jones").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost9 = new Post { Id = 9, StudentId = 9, InstructorId = context.Users.Where(u => u.FullName == "Mrs. Smith").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost10 = new Post { Id = 10, StudentId = 10, InstructorId = context.Users.Where(u => u.FullName == "Mrs. Robinson").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost11= new Post { Id = 11, StudentId = 11, InstructorId = context.Users.Where(u => u.FullName == "Mr. Joyce").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost12= new Post { Id = 12, StudentId = 12, InstructorId = context.Users.Where(u => u.FullName == "Mr. Jones").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost13 = new Post { Id = 13, StudentId = 13, InstructorId = context.Users.Where(u => u.FullName == "Mrs. Smith").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost14 = new Post { Id = 14, StudentId = 14, InstructorId = context.Users.Where(u => u.FullName== "Mrs. Robinson").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost15 = new Post { Id = 15, StudentId = 15, InstructorId = context.Users.Where(u => u.FullName == "Mr. Joyce").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            //var seedpost16 = new Post { Id = 16, StudentId = 16, InstructorId = context.Users.Where(u => u.FullName == "Mr. Jones").SingleOrDefault().Id, Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };


            //context.Posts.Add(seedpost1);
            //context.Posts.Add(seedpost2);
            //context.Posts.Add(seedpost3);
            //context.Posts.Add(seedpost4);
            //context.Posts.Add(seedpost5);
            //context.Posts.Add(seedpost6);
            //context.Posts.Add(seedpost7);
            //context.Posts.Add(seedpost8);
            //context.Posts.Add(seedpost9);
            //context.Posts.Add(seedpost10);
            //context.Posts.Add(seedpost11);
            //context.Posts.Add(seedpost12);
            //context.Posts.Add(seedpost13);
            //context.Posts.Add(seedpost14);
            //context.Posts.Add(seedpost15);
            //context.Posts.Add(seedpost16);

        }
    }
}
