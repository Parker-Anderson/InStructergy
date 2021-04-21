namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomanyStudentCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseStudent",
                c => new
                    {
                        CourseRefId = c.Int(nullable: false),
                        StudentRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseRefId, t.StudentRefId })
                .ForeignKey("dbo.Course", t => t.CourseRefId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentRefId, cascadeDelete: true)
                .Index(t => t.CourseRefId)
                .Index(t => t.StudentRefId);
            
            AddColumn("dbo.Course", "Student_Id", c => c.Int());
            CreateIndex("dbo.Course", "Student_Id");
            AddForeignKey("dbo.Course", "Student_Id", "dbo.Student", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseStudent", "StudentRefId", "dbo.Student");
            DropForeignKey("dbo.CourseStudent", "CourseRefId", "dbo.Course");
            DropForeignKey("dbo.Course", "Student_Id", "dbo.Student");
            DropIndex("dbo.CourseStudent", new[] { "StudentRefId" });
            DropIndex("dbo.CourseStudent", new[] { "CourseRefId" });
            DropIndex("dbo.Course", new[] { "Student_Id" });
            DropColumn("dbo.Course", "Student_Id");
            DropTable("dbo.CourseStudent");
        }
    }
}
