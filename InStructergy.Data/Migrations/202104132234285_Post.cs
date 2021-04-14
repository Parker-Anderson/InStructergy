namespace InStructergy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Post : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "Body", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "Body");
        }
    }
}
