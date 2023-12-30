namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class file : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Files");
        }
    }
}
