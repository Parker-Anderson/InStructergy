namespace SchoolBoard.Data.Migrations
{
    using System;
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
            // context.Courses.AddOrUpdate(c => c.Id,
            var cscience = new DomainModels.Course() { Id = 1, Name = "Computer Science", InstructorId = "d1f9acc7-33ee-4aeb-bc17-3780694fc471", InstructorGuid = Guid.Parse("d1f9acc7-33ee-4aeb-bc17-3780694fc471") };
            var math = new DomainModels.Course() { Id = 2, Name = "Math", InstructorId = "d1f9acc7-33ee-4aeb-bc17-3780694fc471", InstructorGuid = Guid.Parse("d1f9acc7-33ee-4aeb-bc17-3780694fc471") };
            var physics = new DomainModels.Course() { Id = 3, Name = "Physics", InstructorId = "d1f9acc7-33ee-4aeb-bc17-3780694fc471", InstructorGuid = Guid.Parse("d1f9acc7-33ee-4aeb-bc17-3780694fc471") };
            var art = new DomainModels.Course() { Id = 4, Name = "Art", InstructorId = "d1f9acc7-33ee-4aeb-bc17-3780694fc471", InstructorGuid = Guid.Parse("d1f9acc7-33ee-4aeb-bc17-3780694fc471") };
            var english = new DomainModels.Course() { Id = 5, Name = "English", InstructorId = "d1f9acc7-33ee-4aeb-bc17-3780694fc471", InstructorGuid = Guid.Parse("d1f9acc7-33ee-4aeb-bc17-3780694fc471") };
            var latin = new DomainModels.Course() { Id = 6, Name = "Latin", InstructorId = "d1f9acc7-33ee-4aeb-bc17-3780694fc471", InstructorGuid = Guid.Parse("d1f9acc7-33ee-4aeb-bc17-3780694fc471") };
            var history = new DomainModels.Course() { Id = 7, Name = "History", InstructorId = "d1f9acc7-33ee-4aeb-bc17-3780694fc471", InstructorGuid = Guid.Parse("d1f9acc7-33ee-4aeb-bc17-3780694fc471") };
            var socstudies = new DomainModels.Course() { Id = 8, Name = "Social Studies", InstructorId = "d1f9acc7-33ee-4aeb-bc17-3780694fc471", InstructorGuid = Guid.Parse("d1f9acc7-33ee-4aeb-bc17-3780694fc471") };
            var geography = new DomainModels.Course() { Id = 9, Name = "Geography", InstructorId = "d1f9acc7-33ee-4aeb-bc17-3780694fc471", InstructorGuid = Guid.Parse("d1f9acc7-33ee-4aeb-bc17-3780694fc471") };
            context.Courses.AddOrUpdate(cscience, math, physics, art, english, latin, history, socstudies, geography);
            //);
            //context.Students.AddOrUpdate(s => s.Id,
           
            var bill = new DomainModels.Student() { Id = 1, Name = "Bill", GradePointAverage = 1.5 };
            var karen = new DomainModels.Student() { Id = 2, Name = "Karen", GradePointAverage = 2.0 };
            var bob = new DomainModels.Student() { Id = 3, Name = "Bob", GradePointAverage = 2.5 };
            var katie = new DomainModels.Student() { Id = 4, Name = "Katie", GradePointAverage = 2.7 };
            var joe = new DomainModels.Student() { Id = 5, Name = "Joe", GradePointAverage = 3.0 };
            var susan = new DomainModels.Student() { Id = 6, Name = "Susan", GradePointAverage = 2.3 };
            var jeremy = new DomainModels.Student() { Id = 7, Name = "Jeremy", GradePointAverage = 3.2 };
            var megan = new DomainModels.Student() { Id = 8, Name = "Megan", GradePointAverage = 3.6 };
            var john = new DomainModels.Student() { Id = 9, Name = "John", GradePointAverage = 2.0 };
            var amanda = new DomainModels.Student() { Id = 10, Name = "Amanda", GradePointAverage = 4.0 };
            //);
            context.Students.AddOrUpdate(bill, karen, bob, katie, joe, susan, jeremy, megan, john, amanda);

            //amanda.Courses.Add(latin);
         //   amanda.Courses.Add(history);
         //   amanda.Courses.Add(math);
         //   john.Courses.Add(art);
         //   bill.Courses.Add(cscience);
         //   bill.Courses.Add(latin);
         //   karen.Courses.Add(cscience);
         //   bob.Courses.Add(math);
         //   katie.Courses.Add(history);
         //   joe.Courses.Add(socstudies);
         //   susan.Courses.Add(geography);
         ////   jeremy.Courses.Add(physics);
         //   //megan.Courses.Add(cscience);//








        }
    }
}
