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
            context.Courses.AddOrUpdate(c => c.Id,
                new DomainModels.Course() { Id = 1, Name = "Computer Science", InstructorId = "cf45c79c-e064-485d-988d-bfb54e38174e" },
                new DomainModels.Course() { Id = 2, Name = "Math", InstructorId = "cf45c79c-e064-485d-988d-bfb54e38174e" },
                new DomainModels.Course() { Id = 3, Name = "Physics", InstructorId = "cf45c79c-e064-485d-988d-bfb54e38174e" }

                );
        }
    }
}
