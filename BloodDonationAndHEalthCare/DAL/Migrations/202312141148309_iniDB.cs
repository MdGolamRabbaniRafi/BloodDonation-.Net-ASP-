namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iniDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAdmins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserAdmins");
        }
    }
}
