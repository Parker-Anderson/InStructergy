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
                new DomainModels.Course() { Id = 1, Name = "Computer Science", InstructorId = "5665fd82-06aa-4266-8f60-746dd8d5b9b2", InstructorGuid=Guid.Parse("5665fd82-06aa-4266-8f60-746dd8d5b9b2") },
                new DomainModels.Course() { Id = 2, Name = "Math", InstructorId = "5665fd82-06aa-4266-8f60-746dd8d5b9b2", InstructorGuid = Guid.Parse("5665fd82-06aa-4266-8f60-746dd8d5b9b2") },
                new DomainModels.Course() { Id = 3, Name = "Physics", InstructorId = "5665fd82-06aa-4266-8f60-746dd8d5b9b2", InstructorGuid = Guid.Parse("5665fd82-06aa-4266-8f60-746dd8d5b9b2") },
                new DomainModels.Course() { Id = 4, Name = "Art", InstructorId = "d15aa072-14ec-4ce4-86ec-7432bc0d8de2", InstructorGuid = Guid.Parse("d15aa072-14ec-4ce4-86ec-7432bc0d8de2") },
                new DomainModels.Course() { Id = 5, Name = "English", InstructorId = "d15aa072-14ec-4ce4-86ec-7432bc0d8de2", InstructorGuid = Guid.Parse("d15aa072-14ec-4ce4-86ec-7432bc0d8de2") },
                new DomainModels.Course() { Id = 6, Name = "Latin", InstructorId = "d15aa072-14ec-4ce4-86ec-7432bc0d8de2", InstructorGuid = Guid.Parse("d15aa072-14ec-4ce4-86ec-7432bc0d8de2") },
                new DomainModels.Course() { Id = 7, Name = "History", InstructorId = "63d9cb1a-1d7a-4d3a-87aa-72ec79a70d7e", InstructorGuid = Guid.Parse("63d9cb1a-1d7a-4d3a-87aa-72ec79a70d7e") },
                new DomainModels.Course() { Id = 8, Name = "Social Studies", InstructorId = "63d9cb1a-1d7a-4d3a-87aa-72ec79a70d7e", InstructorGuid = Guid.Parse("63d9cb1a-1d7a-4d3a-87aa-72ec79a70d7e") },
                new DomainModels.Course() { Id = 9, Name = "Geography", InstructorId = "63d9cb1a-1d7a-4d3a-87aa-72ec79a70d7e", InstructorGuid = Guid.Parse("63d9cb1a-1d7a-4d3a-87aa-72ec79a70d7e") }
                );
            context.Students.AddOrUpdate(s => s.Id,
                new DomainModels.Student() { Id = 1, Name = "Bill", GradePointAverage = 1.5 },
                new DomainModels.Student() { Id = 2, Name = "Karen", GradePointAverage = 2.0 },
                new DomainModels.Student() { Id = 3, Name = "Bob", GradePointAverage = 2.5 },
                new DomainModels.Student() { Id = 4, Name = "Katie", GradePointAverage = 2.7 },
                new DomainModels.Student() { Id = 5, Name = "Joe", GradePointAverage = 3.0 },
                new DomainModels.Student() { Id = 6, Name = "Susan", GradePointAverage = 2.3 },
                new DomainModels.Student() { Id = 7, Name = "Jeremy", GradePointAverage = 3.2 },
                new DomainModels.Student() { Id = 8, Name = "Megan", GradePointAverage = 3.6 },
                new DomainModels.Student() { Id = 9, Name = "John", GradePointAverage = 2.0 },
                new DomainModels.Student() { Id = 10, Name = "Amanda", GradePointAverage = 4.0 }
                );
        }
    }
}
