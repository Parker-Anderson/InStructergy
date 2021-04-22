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
            context.Users.AddOrUpdate(c => c.Id,
               new SchoolBoard.Data.ApplicationUser() { Id = "2371064d-3077-4bcb-a91d-ba89b1bc5562", Email = "test2@test.com", EmailConfirmed = false, PasswordHash = "AHSkgSapHhYyDjPxvoQMKL8D2QC5eQg6WvYu9fuvOhmL5Cn8DsgqqZwRSXeTbE2FRg==", SecurityStamp = "bc31cc00-992a-454c-ae19-03c89f6015d5", TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0, UserName = "Mrs. Robinson", Name = "Mrs. Robinson" },
               new SchoolBoard.Data.ApplicationUser() { Id = "2729b303-5557-4e1a-8422-bc311b06ee17", Email = "teacher@teacher.com", EmailConfirmed = false, PasswordHash = "AGtN9rH5KsC7rGey47hwLzb4b4SY1YuDz+hvHB5LaG1UcierZqT23W7fgKUMLdR+bg==", SecurityStamp = "58a39ba7-6d83-42df-9158-687105b75dcd", TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0, UserName = "Mr. Jones", Name = "Mr. Jones" },
               new SchoolBoard.Data.ApplicationUser() { Id = "cf45c79c-e064-485d-988d-bfb54e38174e", Email = "test@test.com", EmailConfirmed = false, PasswordHash = "ALIX3IjlG9TlnfHiWt8tbpv83YNboQEehEvv449dbt6PeBl7uSLNp7JRyondV460sg==", SecurityStamp = "0d965775-695c-49c9-8811-9240dd3b6137", TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0, UserName = "Mr. Joyce", Name = "Mr. Joyce" },
               new SchoolBoard.Data.ApplicationUser() { Id = "d50bfa7c-0ca5-497c-b4d6-eb2d52c6357a", Email = "email@email.com", EmailConfirmed = false, PasswordHash = "ADwNL/a0J1cckDIDixHIfrtI15nvLQ0xp6vJtkW4iuRqp8/vchuAU2vH6uaf3ZcrmA==", SecurityStamp = "2fc12aec-5ab7-4ae5-8df5-a21f974f22f1", TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0, UserName = "Ms. Jones", Name = "Ms. Jones" }
               );





        }
    }
}
