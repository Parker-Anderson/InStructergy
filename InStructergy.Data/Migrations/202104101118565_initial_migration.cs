namespace InStructergy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "Role_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ApplicationUser", "Role_Id");
            AddForeignKey("dbo.ApplicationUser", "Role_Id", "dbo.IdentityRole", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUser", "Role_Id", "dbo.IdentityRole");
            DropIndex("dbo.ApplicationUser", new[] { "Role_Id" });
            DropColumn("dbo.ApplicationUser", "Role_Id");
        }
    }
}
