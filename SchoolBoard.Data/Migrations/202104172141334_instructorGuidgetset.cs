namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class instructorGuidgetset : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "InstructorGuid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "InstructorGuid");
        }
    }
}
