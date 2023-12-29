namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postService : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropTable("dbo.Posts");
        }
    }
}
