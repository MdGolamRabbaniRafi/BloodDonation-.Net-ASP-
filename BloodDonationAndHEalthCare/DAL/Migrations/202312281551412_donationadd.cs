namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class donationadd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "ServiceProviderID", "dbo.ServiceProviders");
            DropIndex("dbo.Users", new[] { "ServiceProviderID" });
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ApprovedAt = c.DateTime(),
                        IsPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Users", "ServiceProviderID");
            DropTable("dbo.ServiceProviders");
        }
        
        public override void Down()
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
            DropTable("dbo.Donations");
            CreateIndex("dbo.Users", "ServiceProviderID");
            AddForeignKey("dbo.Users", "ServiceProviderID", "dbo.ServiceProviders", "Id", cascadeDelete: true);
        }
    }
}
