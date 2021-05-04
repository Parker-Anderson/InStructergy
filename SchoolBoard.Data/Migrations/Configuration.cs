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
            var bill = new Student { Id = 1, Name = "Bill" };
            var amanda = new Student { Id = 2, Name = "Amanda" };
            var kyle = new Student { Id = 3, Name = "Kyle" };
            var heather = new Student { Id = 4, Name = "Heather" };
            context.Students.Add(bill);
            context.Students.Add(amanda);
            context.Students.Add(kyle);
            context.Students.Add(heather);

            context.Courses.AddOrUpdate(
                c => c.CourseName,
                new DataModels.Course { CourseName = "Computer Science", Instructor = context.Users.Where(u => u.Name == "Mrs. Smith").SingleOrDefault(), Students = new List<Student>() { bill, amanda, kyle, heather } },
                new DataModels.Course { CourseName = "Art", Instructor = context.Users.Where(u => u.Name == "Mrs. Robinson").SingleOrDefault(), Students = new List<Student>() { bill, amanda, kyle, heather } });


            var seedpost1 = new Post { Id = 1, StudentId = 1, InstructorId = "0b424b75-9f46-4581-8173-d71154957529", Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            var seedpost2 = new Post { Id = 2, StudentId = 2, InstructorId = "0b424b75-9f46-4581-8173-d71154957529", Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            var seedpost3 = new Post { Id = 3, StudentId = 3, InstructorId = "e2529e7d-ae7d-4322-8835-76fc9a8837e3", Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            var seedpost4 = new Post { Id = 4, StudentId = 4, InstructorId = "e2529e7d-ae7d-4322-8835-76fc9a8837e3", Title = "First Post", Body = "This is the first post on the board for this student.", Created = DateTime.Now };
            context.Posts.Add(seedpost1);
            context.Posts.Add(seedpost2);
            context.Posts.Add(seedpost3);
            context.Posts.Add(seedpost4);

        }
    }
}
