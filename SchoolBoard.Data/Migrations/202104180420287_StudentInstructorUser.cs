namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentInstructorUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Instructor_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Student", "Instructor_Id");
            AddForeignKey("dbo.Student", "Instructor_Id", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "Instructor_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Student", new[] { "Instructor_Id" });
            DropColumn("dbo.Student", "Instructor_Id");
        }
    }
}
