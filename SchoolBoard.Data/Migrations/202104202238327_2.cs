namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Student", "Instructor_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Student", new[] { "Instructor_Id" });
            DropColumn("dbo.Student", "InstructorGuid");
            DropColumn("dbo.Student", "Instructor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "Instructor_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Student", "InstructorGuid", c => c.Guid(nullable: false));
            CreateIndex("dbo.Student", "Instructor_Id");
            AddForeignKey("dbo.Student", "Instructor_Id", "dbo.ApplicationUser", "Id");
        }
    }
}
