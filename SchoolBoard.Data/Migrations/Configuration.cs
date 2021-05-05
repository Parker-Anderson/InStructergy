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
        var heather = new Student { Id = 4, Name = "Heather", GPA = 2.4 };
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
            new SchoolBoard.Data.DataModels.Course { CourseName = "Computer Science", Instructor = context.Users.Where(u => u.Email == "Robinson@email.com").SingleOrDefault(), Students = new List<Student>() { bill, amanda, kyle, heather, james, leiah, mario, dakota, todd } },
            new SchoolBoard.Data.DataModels.Course { CourseName = "Art", Instructor = context.Users.Where(u => u.Email == "Robinson@email.com").SingleOrDefault(), Students = new List<Student>() { bill, amanda, kyle, heather, jessica, joey, luke, leiah, nicholas, rachel, pete } },
            new SchoolBoard.Data.DataModels.Course { CourseName = "History", Instructor = context.Users.Where(u => u.Email == "smith@email.com").SingleOrDefault(), Students = new List<Student>() { heather, james, leiah, jessica, joey, pete, dakota, bill, amanda } },
            new SchoolBoard.Data.DataModels.Course { CourseName = "Social Studies", Instructor = context.Users.Where(u => u.Email == "Robinson@email.com").SingleOrDefault(), Students = new List<Student>() { joey, jessica, pete, mario, todd, amanda, rachel } },
            new SchoolBoard.Data.DataModels.Course { CourseName = "Physics", Instructor = context.Users.Where(u => u.Email == "jones@email.com").SingleOrDefault(), Students = new List<Student>() { heather, kyle, mario, joey, todd, dakota, bill } },
            new SchoolBoard.Data.DataModels.Course { CourseName = "Geography", Instructor = context.Users.Where(u => u.Email == "smith@email.com").SingleOrDefault(), Students = new List<Student>() { nicholas, rachel, pete, jessica, leiah, luke } });

    }
}

