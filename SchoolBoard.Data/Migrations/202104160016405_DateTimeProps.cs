namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "Title", c => c.String());
            AddColumn("dbo.Post", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.PostReply", "Created", c => c.DateTime(nullable: false));
            DropColumn("dbo.Post", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "Name", c => c.String());
            DropColumn("dbo.PostReply", "Created");
            DropColumn("dbo.Post", "Created");
            DropColumn("dbo.Post", "Title");
        }
    }
}
