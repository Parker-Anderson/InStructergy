namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CourseStudent", name: "CourseRefId", newName: "CourseId");
            RenameColumn(table: "dbo.CourseStudent", name: "StudentRefId", newName: "StudentId");
            RenameIndex(table: "dbo.CourseStudent", name: "IX_CourseRefId", newName: "IX_CourseId");
            RenameIndex(table: "dbo.CourseStudent", name: "IX_StudentRefId", newName: "IX_StudentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CourseStudent", name: "IX_StudentId", newName: "IX_StudentRefId");
            RenameIndex(table: "dbo.CourseStudent", name: "IX_CourseId", newName: "IX_CourseRefId");
            RenameColumn(table: "dbo.CourseStudent", name: "StudentId", newName: "StudentRefId");
            RenameColumn(table: "dbo.CourseStudent", name: "CourseId", newName: "CourseRefId");
        }
    }
}
