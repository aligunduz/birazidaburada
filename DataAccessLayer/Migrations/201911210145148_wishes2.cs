namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wishes2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wishes", "Users_Id", "dbo.Users");
            DropIndex("dbo.Wishes", new[] { "Users_Id" });
            DropTable("dbo.Wishes");
        }
    }
}
