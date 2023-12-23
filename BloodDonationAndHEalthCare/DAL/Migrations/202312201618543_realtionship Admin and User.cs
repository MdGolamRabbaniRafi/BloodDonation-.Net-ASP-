namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class realtionshipAdminandUser : DbMigration
    {
        public override void Up()
        {
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
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserAdmins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "AdminId", "dbo.UserAdmins");
            DropIndex("dbo.Users", new[] { "AdminId" });
            DropTable("dbo.Users");
        }
    }
}
