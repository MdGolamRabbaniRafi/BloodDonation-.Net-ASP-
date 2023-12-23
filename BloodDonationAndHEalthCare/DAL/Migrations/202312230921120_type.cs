namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class type : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tokens", "UserType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tokens", "UserType");
        }
    }
}
