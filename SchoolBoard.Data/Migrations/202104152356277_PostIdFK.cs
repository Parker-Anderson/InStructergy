namespace SchoolBoard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostIdFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostReply", "Post_Id", "dbo.Post");
            DropIndex("dbo.PostReply", new[] { "Post_Id" });
            RenameColumn(table: "dbo.PostReply", name: "Post_Id", newName: "PostId");
            AlterColumn("dbo.PostReply", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.PostReply", "PostId");
            AddForeignKey("dbo.PostReply", "PostId", "dbo.Post", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostReply", "PostId", "dbo.Post");
            DropIndex("dbo.PostReply", new[] { "PostId" });
            AlterColumn("dbo.PostReply", "PostId", c => c.Int());
            RenameColumn(table: "dbo.PostReply", name: "PostId", newName: "Post_Id");
            CreateIndex("dbo.PostReply", "Post_Id");
            AddForeignKey("dbo.PostReply", "Post_Id", "dbo.Post", "Id");
        }
    }
}
