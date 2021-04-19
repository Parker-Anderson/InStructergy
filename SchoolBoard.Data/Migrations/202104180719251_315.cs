namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _315 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Student", name: "InstructorId", newName: "Instructor_Id");
            RenameIndex(table: "dbo.Student", name: "IX_InstructorId", newName: "IX_Instructor_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Student", name: "IX_Instructor_Id", newName: "IX_InstructorId");
            RenameColumn(table: "dbo.Student", name: "Instructor_Id", newName: "InstructorId");
        }
    }
}
