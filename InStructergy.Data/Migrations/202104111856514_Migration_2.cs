namespace InStructergy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Course", "InstructorId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Course", "InstructorId", c => c.String());
        }
    }
}
