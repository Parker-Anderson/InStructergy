namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostReply : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostReply",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstructorId = c.String(maxLength: 128),
                        Label = c.String(),
                        Body = c.String(),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.InstructorId)
                .ForeignKey("dbo.Post", t => t.Post_Id)
                .Index(t => t.InstructorId)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostReply", "Post_Id", "dbo.Post");
            DropForeignKey("dbo.PostReply", "InstructorId", "dbo.ApplicationUser");
            DropIndex("dbo.PostReply", new[] { "Post_Id" });
            DropIndex("dbo.PostReply", new[] { "InstructorId" });
            DropTable("dbo.PostReply");
        }
    }
}
