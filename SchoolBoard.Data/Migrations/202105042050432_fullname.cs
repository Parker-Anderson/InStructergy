namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fullname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "FullName", c => c.String());
            DropColumn("dbo.ApplicationUser", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "Name", c => c.String());
            DropColumn("dbo.ApplicationUser", "FullName");
        }
    }
}
