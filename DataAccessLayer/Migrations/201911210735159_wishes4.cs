namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wishes4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wishes", "Products_Id", c => c.Int());
            CreateIndex("dbo.Wishes", "Products_Id");
            AddForeignKey("dbo.Wishes", "Products_Id", "dbo.Products", "Id");
            DropColumn("dbo.Wishes", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wishes", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Wishes", "Products_Id", "dbo.Products");
            DropIndex("dbo.Wishes", new[] { "Products_Id" });
            DropColumn("dbo.Wishes", "Products_Id");
        }
    }
}
