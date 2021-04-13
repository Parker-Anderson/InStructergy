namespace InStructergy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InstructorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.InstructorId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Role_Id = c.String(maxLength: 128),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityRole", t => t.Role_Id)
                .ForeignKey("dbo.Student", t => t.Student_Id)
                .Index(t => t.Role_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InstructorId = c.Guid(nullable: false),
                        GradePointAverage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileType = c.String(),
                        FileLocation = c.String(),
                        PostId = c.Int(nullable: false),
                        OwnerId = c.String(maxLength: 128),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.OwnerId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.Student_Id)
                .Index(t => t.PostId)
                .Index(t => t.OwnerId)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InstructorId = c.String(maxLength: 128),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.InstructorId)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.InstructorId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id })
                .ForeignKey("dbo.Student", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.ApplicationUser", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.File", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.File", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Post", "InstructorId", "dbo.ApplicationUser");
            DropForeignKey("dbo.File", "OwnerId", "dbo.ApplicationUser");
            DropForeignKey("dbo.StudentCourse", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.StudentCourse", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.Course", "InstructorId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUser", "Role_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.StudentCourse", new[] { "Course_Id" });
            DropIndex("dbo.StudentCourse", new[] { "Student_Id" });
            DropIndex("dbo.Post", new[] { "StudentId" });
            DropIndex("dbo.Post", new[] { "InstructorId" });
            DropIndex("dbo.File", new[] { "Student_Id" });
            DropIndex("dbo.File", new[] { "OwnerId" });
            DropIndex("dbo.File", new[] { "PostId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUser", new[] { "Student_Id" });
            DropIndex("dbo.ApplicationUser", new[] { "Role_Id" });
            DropIndex("dbo.Course", new[] { "InstructorId" });
            DropTable("dbo.StudentCourse");
            DropTable("dbo.Post");
            DropTable("dbo.File");
            DropTable("dbo.Student");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Course");
        }
    }
}
