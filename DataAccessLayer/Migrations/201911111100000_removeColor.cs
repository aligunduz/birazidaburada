namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeColor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Color", c => c.String());
        }
    }
}
