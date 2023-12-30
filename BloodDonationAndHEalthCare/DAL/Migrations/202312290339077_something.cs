namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class something : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "AdminId", "dbo.UserAdmins");
            DropIndex("dbo.Users", new[] { "AdminId" });
            AlterColumn("dbo.Users", "AdminId", c => c.Int());
            CreateIndex("dbo.Users", "AdminId");
            AddForeignKey("dbo.Users", "AdminId", "dbo.UserAdmins", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "AdminId", "dbo.UserAdmins");
            DropIndex("dbo.Users", new[] { "AdminId" });
            AlterColumn("dbo.Users", "AdminId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "AdminId");
            AddForeignKey("dbo.Users", "AdminId", "dbo.UserAdmins", "Id", cascadeDelete: true);
        }
    }
}
