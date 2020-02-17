namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletewishes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wishes", "Products_Id", "dbo.Products");
            DropIndex("dbo.Wishes", new[] { "Products_Id" });
            DropIndex("dbo.Wishes", new[] { "Users_Id" });
            AddColumn("dbo.Products", "Users_Id", c => c.Int());
            CreateIndex("dbo.Products", "Users_Id");
            DropTable("dbo.Wishes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Wishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Products_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.Products", new[] { "Users_Id" });
            DropColumn("dbo.Products", "Users_Id");
            CreateIndex("dbo.Wishes", "Users_Id");
            CreateIndex("dbo.Wishes", "Products_Id");
            AddForeignKey("dbo.Wishes", "Products_Id", "dbo.Products", "Id");
        }
    }
}
