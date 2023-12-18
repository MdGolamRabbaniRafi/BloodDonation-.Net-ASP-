namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createProfileOfAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAdmins", "BloodGroup", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAdmins", "BloodGroup");
        }
    }
}
