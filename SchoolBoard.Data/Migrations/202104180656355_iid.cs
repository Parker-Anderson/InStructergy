namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Student", name: "Instructor_Id", newName: "InstructorId");
            RenameIndex(table: "dbo.Student", name: "IX_Instructor_Id", newName: "IX_InstructorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Student", name: "IX_InstructorId", newName: "IX_Instructor_Id");
            RenameColumn(table: "dbo.Student", name: "InstructorId", newName: "Instructor_Id");
        }
    }
}
