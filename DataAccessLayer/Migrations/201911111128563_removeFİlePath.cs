namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeFİlePath : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductImages", "FilePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductImages", "FilePath", c => c.String());
        }
    }
}
