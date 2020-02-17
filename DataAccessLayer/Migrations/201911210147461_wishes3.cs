namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wishes3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Wishes", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wishes", "UserId", c => c.Int(nullable: false));
        }
    }
}
