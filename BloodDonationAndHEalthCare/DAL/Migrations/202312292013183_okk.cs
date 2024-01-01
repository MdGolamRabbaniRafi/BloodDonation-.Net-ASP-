namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class okk : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "AdminId", "dbo.UserAdmins");
            DropIndex("dbo.Users", new[] { "AdminId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.UserAdmins");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
        }
    }
}
