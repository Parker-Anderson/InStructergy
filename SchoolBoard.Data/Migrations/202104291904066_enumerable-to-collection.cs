namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enumerabletocollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "Student_Id", c => c.Int());
            CreateIndex("dbo.ApplicationUser", "Student_Id");
            AddForeignKey("dbo.ApplicationUser", "Student_Id", "dbo.Student", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUser", "Student_Id", "dbo.Student");
            DropIndex("dbo.ApplicationUser", new[] { "Student_Id" });
            DropColumn("dbo.ApplicationUser", "Student_Id");
        }
    }
}
