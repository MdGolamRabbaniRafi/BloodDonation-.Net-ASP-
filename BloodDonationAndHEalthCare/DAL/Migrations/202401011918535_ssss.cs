namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ssss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompleteDonations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonerId = c.Int(nullable: false),
                        Phone = c.String(),
                        Location = c.String(),
                        Problems = c.String(),
                        DonationTime = c.DateTime(nullable: false),
                        NextDonationTime = c.DateTime(nullable: false),
                        ReceverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ApprovedAt = c.DateTime(),
                        IsPaid = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Password = c.String(),
                        BloodGroup = c.String(),
                        UserType = c.String(),
                        AdminId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserAdmins", t => t.AdminId)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.HelpPosts",
                c => new
                    {
                        HelpPostId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Location = c.String(),
                        Problems = c.String(),
                        Amount = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HelpPostId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BloodGroup = c.String(),
                        Phone = c.String(),
                        Location = c.String(),
                        Problems = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserAdmins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        BloodGroup = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        UserId = c.Int(nullable: false),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tkey = c.String(nullable: false, maxLength: 100),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(),
                        UserId = c.String(nullable: false),
                        UserType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "AdminId", "dbo.UserAdmins");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.HelpPosts", "UserId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.HelpPosts", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "AdminId" });
            DropIndex("dbo.Donations", new[] { "UserId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Files");
            DropTable("dbo.UserAdmins");
            DropTable("dbo.Posts");
            DropTable("dbo.HelpPosts");
            DropTable("dbo.Users");
            DropTable("dbo.Donations");
            DropTable("dbo.CompleteDonations");
        }
    }
}
