namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListstoIENUM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentCourse", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.StudentCourse", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.File", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.ApplicationUser", "Student_Id", "dbo.Student");
            DropIndex("dbo.ApplicationUser", new[] { "Student_Id" });
            DropIndex("dbo.File", new[] { "Student_Id" });
            DropIndex("dbo.StudentCourse", new[] { "Student_Id" });
            DropIndex("dbo.StudentCourse", new[] { "Course_Id" });
            DropColumn("dbo.ApplicationUser", "Student_Id");
            DropColumn("dbo.File", "Student_Id");
            DropTable("dbo.StudentCourse");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id });
            
            AddColumn("dbo.File", "Student_Id", c => c.Int());
            AddColumn("dbo.ApplicationUser", "Student_Id", c => c.Int());
            CreateIndex("dbo.StudentCourse", "Course_Id");
            CreateIndex("dbo.StudentCourse", "Student_Id");
            CreateIndex("dbo.File", "Student_Id");
            CreateIndex("dbo.ApplicationUser", "Student_Id");
            AddForeignKey("dbo.ApplicationUser", "Student_Id", "dbo.Student", "Id");
            AddForeignKey("dbo.File", "Student_Id", "dbo.Student", "Id");
            AddForeignKey("dbo.StudentCourse", "Course_Id", "dbo.Course", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourse", "Student_Id", "dbo.Student", "Id", cascadeDelete: true);
        }
    }
}
