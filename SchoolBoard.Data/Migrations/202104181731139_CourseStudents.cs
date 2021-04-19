namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseStudents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "Student_Id", c => c.Int());
            CreateIndex("dbo.Course", "Student_Id");
            AddForeignKey("dbo.Course", "Student_Id", "dbo.Student", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "Student_Id", "dbo.Student");
            DropIndex("dbo.Course", new[] { "Student_Id" });
            DropColumn("dbo.Course", "Student_Id");
        }
    }
}
