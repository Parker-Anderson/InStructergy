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
                new DomainModels.Course() { Id = 1, Name = "Computer Science", InstructorId = "2371064d-3077-4bcb-a91d-ba89b1bc5562", InstructorGuid=Guid.Parse("2371064d-3077-4bcb-a91d-ba89b1bc5562") },
                new DomainModels.Course() { Id = 2, Name = "Math", InstructorId = "2371064d-3077-4bcb-a91d-ba89b1bc5562", InstructorGuid = Guid.Parse("2371064d-3077-4bcb-a91d-ba89b1bc5562") },
                new DomainModels.Course() { Id = 3, Name = "Physics", InstructorId = "2371064d-3077-4bcb-a91d-ba89b1bc5562", InstructorGuid = Guid.Parse("2371064d-3077-4bcb-a91d-ba89b1bc5562") },
                new DomainModels.Course() { Id = 4, Name = "Art", InstructorId = "2371064d-3077-4bcb-a91d-ba89b1bc5562", InstructorGuid = Guid.Parse("2371064d-3077-4bcb-a91d-ba89b1bc5562") },
                new DomainModels.Course() { Id = 5, Name = "English", InstructorId = "2371064d-3077-4bcb-a91d-ba89b1bc5562", InstructorGuid = Guid.Parse("2371064d-3077-4bcb-a91d-ba89b1bc5562") },
                new DomainModels.Course() { Id = 6, Name = "Latin", InstructorId = "cf45c79c-e064-485d-988d-bfb54e38174e", InstructorGuid = Guid.Parse("cf45c79c-e064-485d-988d-bfb54e38174e") },
                new DomainModels.Course() { Id = 7, Name = "History", InstructorId = "cf45c79c-e064-485d-988d-bfb54e38174e", InstructorGuid = Guid.Parse("cf45c79c-e064-485d-988d-bfb54e38174e") },
                new DomainModels.Course() { Id = 8, Name = "Social Studies", InstructorId = "cf45c79c-e064-485d-988d-bfb54e38174e", InstructorGuid = Guid.Parse("cf45c79c-e064-485d-988d-bfb54e38174e") },
                new DomainModels.Course() { Id = 9, Name = "Geography", InstructorId = "cf45c79c-e064-485d-988d-bfb54e38174e", InstructorGuid = Guid.Parse("cf45c79c-e064-485d-988d-bfb54e38174e") }
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
