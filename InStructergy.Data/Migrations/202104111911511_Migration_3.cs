namespace InStructergy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Course", "InstructorId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Course", "InstructorId", c => c.Guid(nullable: false));
        }
    }
}
