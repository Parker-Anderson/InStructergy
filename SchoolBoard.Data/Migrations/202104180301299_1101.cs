namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1101 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "InstructorGuid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "InstructorGuid");
        }
    }
}
