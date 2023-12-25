namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceprovideradd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceProviders",
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
            
            AddColumn("dbo.Users", "ServiceProviderID", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "ServiceProviderID");
            AddForeignKey("dbo.Users", "ServiceProviderID", "dbo.ServiceProviders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ServiceProviderID", "dbo.ServiceProviders");
            DropIndex("dbo.Users", new[] { "ServiceProviderID" });
            DropColumn("dbo.Users", "ServiceProviderID");
            DropTable("dbo.ServiceProviders");
        }
    }
}
