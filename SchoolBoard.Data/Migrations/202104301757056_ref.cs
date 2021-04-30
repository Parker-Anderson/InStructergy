namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _ref : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CourseStudent", name: "CourseId", newName: "CourseRefId");
            RenameColumn(table: "dbo.CourseStudent", name: "StudentId", newName: "StudentRefId");
            RenameIndex(table: "dbo.CourseStudent", name: "IX_CourseId", newName: "IX_CourseRefId");
            RenameIndex(table: "dbo.CourseStudent", name: "IX_StudentId", newName: "IX_StudentRefId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CourseStudent", name: "IX_StudentRefId", newName: "IX_StudentId");
            RenameIndex(table: "dbo.CourseStudent", name: "IX_CourseRefId", newName: "IX_CourseId");
            RenameColumn(table: "dbo.CourseStudent", name: "StudentRefId", newName: "StudentId");
            RenameColumn(table: "dbo.CourseStudent", name: "CourseRefId", newName: "CourseId");
        }
    }
}
